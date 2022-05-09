import Vue from 'vue';
import App from './App.vue';
import { router } from './router';
import store from './store';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import Vuex from 'vuex';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import axios from 'axios'
import Carousel3d from 'vue-carousel-3d';


axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'
axios.defaults.headers.common['Content-Type'] = 'application/json';
axios.defaults.headers.common['Accept'] = 'application/json';

let token = JSON.parse( localStorage.getItem('token') );
if( token ){
    axios.defaults.headers.common['Authorization'] = 'Bearer ' + token;
}

Vue.config.productionTip = false
Vue.component('font-awesome-icon', FontAwesomeIcon);
Vue.use(Vuex);
Vue.use(Carousel3d);

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
