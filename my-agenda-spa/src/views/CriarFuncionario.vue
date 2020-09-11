<template>
  <div id="criarFuncionario">
    <h1>Novo Estabelecimeno</h1>
    <p v-if="erro != '' || erro != null">{{erro}}</p>
    <form v-on:submit.prevent="metodoCriarEstabelecimento">
      <div class="form-group">
        <label for="exampleInputNome1">Conta do funcionario</label>
        <input
          v-model="funcionario.UsurioEmail"
          ref="nome"
          type="email"
          class="form-control"
          id="exampleInputNome1"
          aria-describedby="nomeHelp"
          placeholder="Entere com o email do funcionario"
          required
        />
      </div>
      <div class="form-group">
        <label for="exampleInputDescricao1">Servico do funcionario</label>
        <input
          v-model="funcionario.NomeServico"
          ref="descricao"
          type="text"
          class="form-control"
          id="exampleInputDescricao1"
          aria-describedby="emailHelp"
          placeholder
          required
        />
      </div>
      <div class="form-group">
        <label for="exampleInputDescricao1">Valor do servico</label>
        <input
          v-model="funcionario.Valor"
          ref="descricao"
          type="text"
          class="form-control"
          id="exampleInputDescricao1"
          aria-describedby="emailHelp"
          placeholder
          required
        />
      </div>
      <div class="form-group">
        <label for="exampleInputDescricao1">Tempo de duracao em minutos do servico</label>
        <input
          v-model="funcionario.TempoDeDuracao"
          ref="descricao"
          type="text"
          class="form-control"
          id="exampleInputDescricao1"
          aria-describedby="emailHelp"
          placeholder
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
export default {
  name: "criarFuncionario",
  data: function () {
    return {
      erro: "",
      funcionario: {
        UsurioEmail: "",
        NomeServico: "",
        Valor: "",
        TempoDeDuracao: "",
        EstabelecimentoId: this.$route.params.id
      },
    };
  },
  computed: {
    ...mapGetters(["usuarioKey"]),
  },
  methods: {
    metodoCriarEstabelecimento: function () {
      //console.log(this.usuarioKey)
      this.funcionario.Valor = Number(this.funcionario.Valor);
      Esta.criarFuncionarioDeEstabelecimento(this.usuarioKey, this.funcionario)
        .then((resposta) => {
          this.erro = "Funcionario criado ";
          console.log(resposta);
        })
        .catch((reason) => {
          if (reason.status === 400) {
            this.erro = "Dados inorrectos, tente novamente" + status;
          } else {
            this.erro = "Erro interno, tente mais tarde " + status;
          }
          //console.log(reason.message)
        });
    },
  },
};
</script>
<style>
#loginECreate {
  width: 60%;
  float: none;
  margin: 0 auto;
  padding-top: 2.5em;
  padding-bottom: 2.5em;
}
</style>