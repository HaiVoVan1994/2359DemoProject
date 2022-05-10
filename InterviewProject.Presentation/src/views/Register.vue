<template>
  <div class="col-md-12">
    <div class="card card-container">
      <form name="form" @submit.prevent="handleRegister">
        <div v-if="!successful">
          <div class="form-group">
            <label for="username">Username</label>
            <input
              v-model="user.username"
              type="text"
              class="form-control"
              name="username"
              required
            />
            <div
              class="alert-danger"
            ></div>
          </div>
          <div class="form-group">
            <label for="password">Password</label>
            <input
              v-model="user.password"
              type="password"
              class="form-control"
              name="password"
              required
            />
            <div
            ></div>
          </div>
          <div class="form-group">
            <label for="email">Email</label>
            <input
              v-model="user.email"
              type="email"
              class="form-control"
              name="email"
              required
            />
            <div>
             </div>
          </div>
          <div class="form-group">
            <label for="dob">Birthday</label>
            <input
              v-model="user.dob"
              type="date"
              class="form-control"
              name="dob"
              required
            />
          </div>
          <div class="form-group">
            <label for="gender">Gender</label>
            <select v-model="user.gender" class="form-control" required>
              <option disabled value="">Please select one</option>
              <option v-for="gender in genders" :key="gender.id" :value="gender.id">{{gender.description}}</option>
            </select>
          </div>
          <div class="form-group mt-2">
            <button class="btn btn-primary btn-block">Sign Up</button>
            <!-- <button class="btn btn-success btn-block ms-2">Login</button> -->
          </div>
        </div>
      </form>

      <div
        v-if="message"
        class="alert"
        :class="successful ? 'alert-success' : 'alert-danger'"
      >{{message}}</div>
    </div>
  </div>
</template>

<script>

import { mapGetters, mapActions } from "vuex"
import axios from 'axios'
export default {
  name: 'Register',
  data() {
    return {
      user: {},
      submitted: false,
      successful: false,
      message: '',
      genders: [
        {
          id: "0",
          description: "Unknown"
        }, 
        {
          id: "1",
          description: "Male"
        },
        {
          id: "2",
          description: "Female"
        },
        {
          id: "3",
          description: "NotApplicable"
        }
      ]
      
    };
  },
  computed: {
    ...mapGetters({
      "userModule": {  token: "getToken", getLoginStatus: "getLoginStatus" }
    })
  },
  methods: {
    ...mapActions("userModule", {
      register: "register",
    }),

    handleRegister() {
        const payload = {
          username: this.user.username,
          password: this.user.password,
          dob: this.user.dob,
          email: this.user.email,
          gender: this.user.gender,
      };

      this.register(payload).then((result) => {
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
  border-radius: 2px;
}

</style>