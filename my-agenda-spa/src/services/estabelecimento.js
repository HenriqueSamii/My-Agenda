import {localhost} from "./config"
import axios from 'axios'

export default {
    estabelecimentoPorNome:(token,nome) => {
        return axios.get(localhost+"estabelecimento/"+nome, {
            headers: {
               Authorization: `Bearer ${token}`
            }
         })
    },
    estabelecimentosDeUsuario:(token) => {
        return axios.get(localhost+"estabelecimento/meus", {
            headers: {
               Authorization: `Bearer ${token}`
            }
         })
    },
    criar:(token,estab) => {
        return axios.post(localhost+'estabelecimento/novo',estab, {
            headers: {
               Authorization: `Bearer ${token}`
            }
         })
    },
    estabelecimentosPorId:(token,id) => {
      //  return axios({ method: 'get', url: localhost+"estabelecimento/agenda", params: { numero: id},headers: {
      //    Authorization: `Bearer ${token}`
      // }})
      return axios.get(localhost+"estabelecimento/agenda/"+ id, {
          headers: {
             Authorization: `Bearer ${token}`
          }
       })
    },
}