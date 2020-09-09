<template>
  <div id="MeuEstabelecimento">
    <router-link tag="button" :to="{name:'CriarEstabelecimento'}">Novo Estabelecimento</router-link>
    <!-- <div class="cardList">
      <div class="carde" v-for="esta of this.agendaUsu" :key="esta">
        <CardEstabelecimentoSimples v-bind:estabelecimentoContent="esta" />
      </div>
    </div> -->
  </div>
</template>

<script>
import { mapGetters } from "vuex";
//import UsuariosBlocosDaAgenda from "@/services/blocoAgenda";
//import CardEstabelecimentoSimples from "@/components/CardEstabelecimentoSimples.vue";
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
    // UsuariosBlocosDaAgenda.home(this.usuarioKey).then((result) => {
    //   var agendaOrdenadada = result.Agenda

    //   function custom_sort(a, b) {
    //     return new Date(a.BlocoDaAgenda.Comeco).getTime() - new Date(b.BlocoDaAgenda.Comeco).getTime();
    //   }

    //   this.agendaUsu = agendaOrdenadada.sort(custom_sort);
    // }).catch((err) => {
    //   console.log(err)
    // });
  },
  components: {
    //CardBlocoDaAgendaSimples
  }
};
</script>
<style>
.criar{
  margin: 0.5em;
}
</style>