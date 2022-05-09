<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <a href class="navbar-brand" @click.prevent></a>
      <div class="navbar-nav mr-auto">
        <li  v-if="loginStatus" class="nav-item">
          <router-link to="/home" class="nav-link">
            Home
          </router-link>
        </li>
      </div>

      <div v-if="!loginStatus" class="navbar-nav ml-auto">
        <li class="nav-item">
          <router-link to="/login" class="nav-link">
            Login
          </router-link>
        </li>
        <li class="nav-item">
          <router-link to="/register" class="nav-link">
            Sign Up
          </router-link>
        </li>
      </div>

      <div v-if="loginStatus" class="navbar-nav ml-auto">
        <li class="nav-item">
          <router-link to="/profile" class="nav-link">
            {{ userInfo.username }}
          </router-link>
        </li>
        <li class="nav-item">
          <a class="nav-link" href @click.prevent="logOut">
            Log out
          </a>
        </li>
      </div>
    </nav>

    <div class="container">
      <router-view />
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";

export default {
  computed: {
    ...mapGetters(
      "authModule", { loginStatus: "getLoginStatus", userInfo: "getUserInfo", logOutStatus: "getlogOutStatus" }
    )
  },
  methods: {
    ...mapActions(
      "authModule", { userLogout : "logOut", setUserInfoAction : "setUserInfoAction", setUserLogout: "setUserLogout"}
    ),

    async logOut() {
        await this.userLogout()
        this.$router.push("/login");
    }
  }
};
</script>
