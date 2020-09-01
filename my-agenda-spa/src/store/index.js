import Vue from 'vue'
import Vuex from 'vuex'
import usuario from "./modules/usuario";

Vue.use(Vuex)

export default new Vuex.Store({
  modules:{
    usuario
  }
})