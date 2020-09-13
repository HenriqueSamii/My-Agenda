<template>
  <div id="criarBlocoAgenda">
    <h1>{{this.estabelecimeto.nome}}</h1>
    <p>Descrição: {{this.estabelecimeto.descricao}}</p>
    <p v-if="erro != '' || erro != null">{{erro}}</p>
    <form v-on:submit.prevent="metodoMarcarBlocoDaAgenda">
      <div class="form-group">
        <label for="exampleInputEmail">Conta (E-mail) de quem esta marcando</label>
        <input
          v-model="ClienteEmailV"
          ref="nome"
          type="email"
          class="form-control"
          id="exampleInputEmail"
          aria-describedby="nomeHelp"
          placeholder="Entere com o seu email"
          required
        />
      </div>
      <div class="form-group">
        <label for="exampleselect">Conta do funcionario</label>
        <b-form-select v-model="servio" :options="options"></b-form-select>
        <!-- <select
          v-model="servio"
          ref="nome"
          class="form-control"
          id="exampleselect"
          :options="options"
          required
        /> -->
      </div>
      <div class="form-group">
        <label for="exampleInputDataTempo">Data e hora do servico</label>
        <input
          v-model="dateTime"
          ref="descricao"
          type="text"
          class="form-control"
          id="exampleInputDataTempo"
          placeholder="Formato ex.: 30-01-2020 14:40"
          required
        />
      </div>
      <button type="submit" class="btn btn-primary">Criar</button>
    </form>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import Esta from "@/services/estabelecimento";
import BolcoAg from "@/services/blocoAgenda";
export default {
  name: "criarFuncionario",
  data: function () {
    return {
      erro: "",
      estabelecimeto: { id: 0, nome: "", descricao: "" },
      //estabelecimetoServicos: [],
      ClienteEmailV: "",
      dateTime: "",
      EstabelecimentoId: 0,
      servio: {},
      options: [],
    };
  },
  computed: {
    ...mapGetters(["usuarioKey"]),
  },
  mounted() {
    Esta.estabelecimentoPorNome(this.usuarioKey, this.$route.params.nome)
      .then((resposta) => {
        this.estabelecimeto.id = resposta.data["usuariosBlocosDaAgenda"].id;
        this.estabelecimeto.nome = resposta.data["usuariosBlocosDaAgenda"].nome;
        this.estabelecimeto.descricao =
          resposta.data["usuariosBlocosDaAgenda"].descricao;

        var optionHolder = [];
        //console.log(resposta.data["usuariosBlocosDaAgenda"].servicos);
        for (const item of resposta.data["usuariosBlocosDaAgenda"].servicos) {
          optionHolder.push({
            value: {
              ServicoId: item.id,
              FuncionarioId: item.prestadores[0].funcionario.conta.id,
            },
            text: `Servico: ${item.nome} - Prestador: ${item.prestadores[0].funcionario.conta.username} - Tempo: ${item.tempoDeDuracao} min. - Custo: ${item.valor}R$`,
          });
        }
        this.options = optionHolder;
        console.log(this.options);
      })
      .catch((reason) => {
        if (reason.status === 400) {
          this.erro = "Dados inorrectos, tente novamente" + reason;
        } else {
          this.erro = "Erro interno, tente mais tarde " + reason;
        }
        console.log(reason.message);
      });
  },
  methods: {
    metodoMarcarBlocoDaAgenda: function () {
      //   var retorno = {
      //     ClienteEmail: this.ClienteEmailV,
      //     FuncionarioId: this.servio.FuncionarioId,
      //     ServicoId: this.servio.ServicoId,
      //     EstabelecimentoId: this.EstabelecimentoId,
      //     inicio: this.dateTime+":00,531",
      //   };
      BolcoAg;
    },
    // myFunction: function (item, index) {
    //   this.options.push(
    //       {
    //           value:
    //           {
    //             ServicoId: item.Id,
    //             FuncionarioId:item.Prestadores[0].Funcionario.Conta.Id,
    //           },
    //           text: `Servico: ${item.nome} - Prestador: ${item.Prestadores[0].Funcionario.Conta.Username} - Tempo: ${item.TempoDeDuracao} min. - Custo: ${item.custo}R$`
    //       }
    //   )
    // }
  },
};
</script>
<style>
#criarBlocoAgenda {
  width: 60%;
  float: none;
  margin: 0 auto;
  padding-top: 2.5em;
  padding-bottom: 2.5em;
}
</style>