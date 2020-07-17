<template>
  <div id="header">
    <b-navbar toggleable="lg" type="dark" variant="dark">
      <router-link tag="b-navbar-brand" :to="{name:'Home'}">Caminho Das Masmorras</router-link>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <router-link tag="b-nav-item" :to="{name:'Home'}">Home</router-link>
          <router-link v-if="isUsuarioLogado" tag="b-nav-item" :to="{name:'Eventos'}">Eventos</router-link>
        </b-navbar-nav>

        <b-navbar-nav class="ml-auto">
          <router-link v-if="!isUsuarioLogado" tag="b-nav-item" :to="{name:'CriarConta'}">Criar Conta</router-link>
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