<template>
  <div class="col-md-12">
    <div class="card card-container">
      <form name="form">
        <div class="form-group">
          <label for="username">Username</label>
          <input
            v-model="user.username"
            type="text"
            class="form-control"
            name="username"
          />
        </div>
        <div class="form-group">
          <label for="password">Password</label>
          <input
            v-model="user.password"
            type="password"
            class="form-control"
            name="password"
          />
        </div>
        <div class="form-group mt-2 ">
          <button type="button" class="btn btn-primary btn-block" :disabled="loading" @click="login(false)">
            <span v-show="loading" class="spinner-border spinner-border-sm"></span>
            <span>Login</span>
          </button>
           <button type="button" class="btn btn-info btn-block ms-2" :disabled="loading" @click="login(true)">
            <span v-show="loading" class="spinner-border spinner-border-sm"></span>
            <span>Login As Admin</span>
          </button>
        </div>
        <div class="form-group">
          <div v-if="message" class="alert alert-danger" role="alert">{{message}}</div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>

import { mapActions, mapGetters } from "vuex";
import axios from 'axios'

export default {
  name: 'Login',
  data() {
    return {
      user: {},
      loading: false,
      message: ''
    };
  },
  computed: {
    ...mapGetters("authModule", {
      getLoginStatus: "getLoginStatus",
      token: "getToken"
    }),
  },
  methods: {
    ...mapActions("authModule", {
      actionLoginApi: "loginApi",
    }),

    login(isAdmin) {
      let payload = {
        username: this.user.username,
        password: this.user.password,
        isAdmin: isAdmin
      }

      if (isAdmin) {
        payload.username ="admin",
        payload.password ="admin"
      }
        
     
      this.actionLoginApi(payload).then((result) => {
          if (result) {
              axios.defaults.headers.common['Authorization'] = 'Bearer ' + this.token;
              localStorage.setItem( 'token', JSON.stringify(this.token) );
              this.$router.push("/Home")
          }
          else {
            alert("fail")
          }
      });
    }
  }
};
</script>

<style scoped>
label {
  display: block;
  margin-top: 10px;
}

.card-container.card {
  max-width: 350px !important;
  padding: 40px 40px;
}

.card {
  background-color: #f7f7f7;
  padding: 20px 25px 30px;
  margin: 0 auto 25px;
  margin-top: 50px;
  -moz-border-radius: 2px;
  -webkit-border-radius: 2px;
  border-radius: 2px;
  -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
}

.profile-img-card {
  width: 96px;
  height: 96px;
  margin: 0 auto 10px;
  display: block;
  -moz-border-radius: 50%;
  -webkit-border-radius: 50%;
  border-radius: 50%;
}
</style>