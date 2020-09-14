<template>
  <div style="padding-top: 2em;" id="EstabelecimentoAgenda">
    <h1>{{this.nome}}</h1>
      <h2 v-if=" this.agendaUsu == null || this.agendaUsu.lenght == 0">Não tem nenhum item agendado</h2>
    <div class="cardList">
      <div class="carde" v-for="post of this.agendaUsu" :key="post">
        <CardBlocoDaAgendaSimples v-bind:agendaContent="post" />
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import EstabelecimentoBlocosDaAgenda from "@/services/estabelecimento";
import CardBlocoDaAgendaSimples from "@/components/CardBlocoDaAgendaSimples.vue";
export default {
  name: "HomeLogado",
  data: function(){
    return{
      nome: "",
      agendaUsu:[],
    };
  },computed: {
    ...mapGetters(["usuarioKey"])
  },
  mounted(){
    EstabelecimentoBlocosDaAgenda.estabelecimentosPorId(this.usuarioKey,this.$route.params.id).then((result) => {
      this.nome = result.data['estabelecimentoPorId'].nome
      this.agendaUsu = result.data['estabelecimentoAgenda']; 
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
/* #EstabelecimentoAgenda{
  margin-top: 2em;
} */
</style>