import Vue from 'vue';
import Vuex from 'vuex';

import authModule from './auth';
import productModule from './product';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    authModule,
    productModule
  }
});
