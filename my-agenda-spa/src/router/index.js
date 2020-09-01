import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import CriarConta from '../views/CriarConta.vue'

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/CriarConta',
    name: 'CriarConta',
    component: CriarConta
  }
]

const router = new VueRouter({
  routes
})

export default router
