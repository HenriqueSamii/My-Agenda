<template>
  <div id="EstabelecimentoAgenda">
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
      //console.log({numero:this.$route.params.id})
    EstabelecimentoBlocosDaAgenda.estabelecimentosPorId(this.usuarioKey,this.$route.params.id).then((result) => {
      var agendaOrdenadada = result.data['estabelecimentoPorId']
      this.nome = agendaOrdenadada['nome']
      this.agendaUsu = agendaOrdenadada['agenda'];
      console.log(agendaOrdenadada)
    //   function custom_sort(a, b) {
    //     return new Date(a.BlocoDaAgenda.Comeco).getTime() - new Date(b.BlocoDaAgenda.Comeco).getTime();
    //   }

    //   this.agendaUsu = agendaOrdenadada.sort(custom_sort);
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