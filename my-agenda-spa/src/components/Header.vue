<template>
<!--<div id="header" class="vue-tempalte">
    
     <nav class="navbar shadow bg-white rounded justify-content-between flex-nowrap flex-row fixed-top">
      <div class="container">
        <a class="navbar-brand float-left" to="/" target="_blank">
           My Agenda
        </a>
        <ul class="nav navbar-nav flex-row float-right">
          <li class="nav-item">
            <router-link class="nav-link pr-3" to="/login">Sign in</router-link>
          </li>
          <li class="nav-item">
            <router-link class="btn btn-outline-primary" to="/">Sign up</router-link>
          </li>
        </ul>
      </div>
    </nav>
 </div> -->
    
  <div id="header">
    <b-navbar class="navbar shadow bg-white rounded justify-content-between flex-nowrap flex-row fixed-top">
      <router-link tag="b-navbar-brand" :to="{name:'Home'}">My Agenda</router-link>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <!-- <b-navbar-nav>
          <router-link tag="b-nav-item" :to="{name:'Home'}">Home</router-link>
          <router-link v-if="isUsuarioLogado" tag="b-nav-item" :to="{name:'Eventos'}">Eventos</router-link>
        </b-navbar-nav> -->

        <b-navbar-nav class="ml-auto">
          <router-link v-if="!isUsuarioLogado" tag="b-nav-item" :to="{name:'Signup'}">Criar Conta</router-link>
          <router-link v-if="!isUsuarioLogado" tag="b-nav-item" :to="{name:'Login'}">Login</router-link>

          <b-nav-item-dropdown right v-if="isUsuarioLogado">
            <template v-slot:button-content>
              <em>User</em>
            </template>
            <b-dropdown-item v-on:click="deslogar">Sign Out</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
export default {
  name: "Header",
  computed: {
    ...mapGetters(["isUsuarioLogado"])
  },
  methods: {
    ...mapActions(["logout"]),
    deslogar: function() {
      this.logout();
      this.$router.push({ name: "Home" });
    },
    computed: function() {}
  }
};
</script>

<style>
#header {
  width: 100%;
}
</style>