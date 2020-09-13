<template>
  <div class="container">
    <div class="card">
      <h2 class="card-title">Data: {{this.agendaContent.blocoDaAgenda.comeco}}</h2>
      <div class="card-body">
        <p class="card-text sideText">Cliente: {{this.agendaContent.usuario.email}} - {{this.agendaContent.usuario.username}}</p>
        <p class="card-text sideText">Prestador: {{this.agendaContent.blocoDaAgenda.prestadores[0].conta.email}} - {{this.agendaContent.blocoDaAgenda.prestadores[0].conta.username}}</p>
        <p class="card-text sideText"  v-if="this.agendaContent.blocoDaAgenda.servicos != null">
          Local: {{this.agendaContent.blocoDaAgenda.local.nome}}</p>
        <p class="card-text mainText"  v-if="this.agendaContent.blocoDaAgenda.servicos != null">
          {{this.agendaContent.blocoDaAgenda.servicos[0].nome}}
          <br>Valor: {{this.agendaContent.blocoDaAgenda.servicos[0].valor}}R$ 
          <br>Duracao: {{this.agendaContent.blocoDaAgenda.servicos[0].duracao}} min.</p>
      </div>
      <!-- <dir class="butoesDiv">
        <button v-if="this.agendaContent.corpo != '' || this.agendaContent.corpo != null"
          class="btn btn-danger btnDeletar"
          type="button"
          v-on:click="cancelarBloco"
        >Canselar</button>
      </dir> -->
    </div>
  </div>
</template>

<script>
// import { mapGetters} from "vuex";
export default {
  name: "home",
  props: {
    agendaContent: Object
  },
  data: function() {
    return {};
  },
  computed: {
    // ...mapGetters(["usuarioKey"])
  },
  methods: {
    // cancelarBloco: function() {
    //   this.deletePost(this.postContent.id);
    // },
  }
};
</script>
<style>
.container {
  width: 70%;
  background-color: transparent;
}
/* .btnEditar,
.btnDeletar {
  width: 50%;
}
.butoesDiv {
  padding: 0%;
  margin: 0%;
  display: inline-block;
} */
.mainText{
  font-size: 1.5em;
}
.sideText{
  font-weight: bold;
}
.card{
  background-color: antiquewhite;
}
</style>