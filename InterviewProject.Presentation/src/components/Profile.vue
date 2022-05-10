<template>
<div class="container">
      <div class="row">
        <div class="user-profile">
            <div>
            <label>User Name: <b>{{ userInfo.username }}</b></label> 
            </div>
            <div>
            <label>Email: <b>{{ userInfo.email }}</b></label> 
            </div>
            <div>
            <label>Birthday: <b>{{ formatDate }}</b></label> 
            </div>
            <div>
            <label>Gender: <b>{{ userInfo.gender }}</b></label> 
            </div>
            <button type="button" class="btn btn-secondary btn-block btn-custom-color" @click="backToHome">
                Back To Home
            </button> 
        </div>
      </div>
    </div>
</template>

<script>

import { mapGetters } from 'vuex'
import moment from 'moment'

export default {
  name: 'Profile',
  computed: {
    ...mapGetters({
       userInfo: "userModule/getUserInfo"
    }),

    formatDate() {
      return moment(String(this.userInfo.dob)).format('MM/DD/YYYY')
    }
  },
  methods: {
    backToHome() {
      this.$router.push("/Home")
    }
  }
};
</script>

<style scoped>
.user-profile {
  line-height: 50px;
}
</style>