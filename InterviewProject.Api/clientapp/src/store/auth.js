import axios from "axios";
const API_URL = 'https://localhost:7083/api/User';

const state = () => ({
    loginStatus: false,
    userInfo: {},
    logOutStatus: false
});

const getters = {
    getLoginStatus(state) {
        return state.loginStatus
    },

    getUserInfo(state) {
      return state.userInfo
    },

    getlogOutStatus(state) {
      return state.logOutStatus
    },

    getToken(state) {
      return state.userInfo.token
    },

    getUserRole(state) {
      return state.userInfo.role
    }
};

const actions = {
    loginApi({ commit }, payload) {
      return new Promise ((resolve, reject) => {
        axios.post(API_URL + "/Login", 
        payload).then(response => {
          if (response && response.data && response.data.isSuccess) {
            commit("setLoginSuccess")
            commit("setUserInfo", response.data.payload)
          } else {
            commit("setLoginFail");
          }
          resolve(true)
        }).catch(e => {
          console.log(e)
          reject(false)
        })
      })
    },

    async logOut({commit}) {
      commit("setLogout", true)
    },

    async setUserInfoAction({commit}) {
      commit("setUserInfo")
    },

    register({commit}, payload) {
      return new Promise ((resolve, reject) => {
        axios.post(API_URL + "/Register", 
        payload).then(response => {
          if (response && response.data && response.data.isSuccess) {
            commit("setLoginSuccess");
            commit("setUserInfo", response.data.payload);
          } else {
            commit("setLoginFail");
          }
          resolve(true)
        }).catch(e => {
          console.log(e)
          reject(false)
        })
      })
    },
};

const mutations = {
    setLoginSuccess(state) {
        state.loginStatus = true
    },

    setUserInfo(state, data) {
      state.userInfo = data
    },

    setLoginFail(state) {
      state.loginStatus = false
    },

    setLogout(state) {
      state.logOutStatus = false
      state.loginStatus = false
      state.userInfo = {}
      localStorage.removeItem('token');
    }
};

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
};
