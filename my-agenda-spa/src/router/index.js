import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import CriarConta from '../views/CriarConta.vue'
import Afiliacoes from '../views/Afiliacoes.vue'
import Agendamento from '../views/Agendamento.vue'
import CriarEstabelecimento from '../views/CriarEstabelecimento.vue'
import CriarFuncionario from '../views/CriarFuncionario.vue'
import MeusEstabelecimentos from '../views/MeusEstabelecimentos.vue'
import Estabelecimento from '../views/Estabelecimento.vue'
import EstabelecimentoAgenda from '../views/EstabelecimentoAgenda.vue'

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
  },
  {
    path: '/Afiliacoes',
    name: 'Afiliacoes',
    component: Afiliacoes
  },
  {
    path: '/MeusEstabelecimentos',
    name: 'MeusEstabelecimentos',
    component: MeusEstabelecimentos
  },
  {
    path: '/agendamento/:negocio',
    name: 'Agendamento',
    component: Agendamento,
  },
  {
    path: '/estabelecimento/criar',
    name: 'CriarEstabelecimento',
    component: CriarEstabelecimento,
  },
  {
    path: '/estabelecimento/funcionario/criar',
    name: 'CriarFuncionario',
    component: CriarFuncionario,
  },
  {
    path: '/estabelecimentos',
    name: 'MeusEstabelecimentos',
    component: MeusEstabelecimentos,
  },
  {
    path: '/estabelecimento/:nome',
    name: 'Estabelecimento',
    component: Estabelecimento,
  },
  {
    path: '/estabelecimento/agenda',
    name: 'EstabelecimentoAgenda',
    component: EstabelecimentoAgenda,
  },
]

const router = new VueRouter({
  routes
})

export default router
