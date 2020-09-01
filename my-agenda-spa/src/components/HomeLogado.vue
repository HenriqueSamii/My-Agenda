<template>
  <div id="homeLogado">
    <h1>Voce logou, vai trabalhar no resto</h1>
    <!-- <h1>Bem vido {{this.usuarioById(this.getUsuarioLogado).nome}}</h1> -->
    <!-- <router-link
      tag="button"
      class="btn btn-primary criar"
      type="submit"
      v-if="isUsuarioLogado"
      :to="{name:'CriarPost' }"
    >Criar Post</router-link> -->
    <!-- <div class="cardList">
      <div class="carde" v-for="post of this.allPosts" :key="post">
        <CardPost v-bind:postContent="post" />
      </div>
    </div> -->
  </div>
</template>

<script>
// import { mapGetters } from "vuex";
// import CardPost from "@/components/CardPost.vue";
export default {
  name: "HomeLogado",
  data: function(){
    return{};
  },computed: {
    // ...mapGetters(["getUsuarioLogado","usuarioById","allPosts","isUsuarioLogado"])
  },
  components: {
    // CardPost
  }
};
</script>
<style>
.criar{
  margin: 0.5em;
}
</style>