<template>
  <div id="homeLogado">
    <!-- <h1>Voce logou, vai trabalhar no resto</h1> -->
    <!-- <h1>Bem vido {{this.usuarioById(this.getUsuarioLogado).nome}}</h1> -->
    <router-link
      tag="button"
      class="btn btn-primary criar"
      type="submit"
      v-if="isUsuarioLogado"
      :to="{name:'CriarPost' }"
    >Criar agendamento pessoal</router-link>
    <h1 v-if=" this.agendaUsu == null ||this.agendaUsu.lenght == 0">Não tem nenhum item agendado</h1>
    <div class="cardList">
      <div class="carde" v-for="post of this.agendaUsu" :key="post">
        <CardBlocoDaAgendaSimples v-bind:agendaContent="post" />
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import UsuariosBlocosDaAgenda from "@/services/blocoAgenda";
import CardBlocoDaAgendaSimples from "@/components/CardBlocoDaAgendaSimples.vue";
export default {
  name: "HomeLogado",
  data: function(){
    return{
      agendaUsu:[]
    };
  },computed: {
    ...mapGetters(["usuarioKey"])
  },
  mounted(){
    UsuariosBlocosDaAgenda.home(this.usuarioKey).then((result) => {
      var agendaOrdenadada = result.data['usuariosBlocosDaAgenda']

      // function custom_sort(a, b) {
      //   return new Date(a.BlocoDaAgenda.Comeco).getTime() - new Date(b.BlocoDaAgenda.Comeco).getTime();
      // }

      this.agendaUsu = agendaOrdenadada;
      console.log(this.agendaUsu)
    }).catch((err) => {
      console.log(err)
    });
  },
  components: {
    CardBlocoDaAgendaSimples
  }
};
</script>
<style>
.criar{
  margin: 0.5em;
}
</style>