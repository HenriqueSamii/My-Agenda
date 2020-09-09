import {localhost} from "./config"
import axios from 'axios'

export default {
    estabelecimentoPorNome:(token,nome) => {
        return axios.get(localhost+"Estabelecimento/"+nome, {
            headers: {
               Authorization: `Bearer ${token}`
            }
         })
    },
    criar:(token,estab) => {
        /*var i = axios.create({
            baseURL:' http://localhost:5000/api/',
            headers: {'Authorization': 'Bearer '+token}
          })*/
        //   console.log(token)
        // return http.get("Estabelecimento/novo",estab, {
        //     headers: {
        //        Authorization: 'Bearer ' + token,
        //     }
        //  })
        return axios.post(localhost+'Estabelecimento/novo',estab, {
            headers: {
               Authorization: `Bearer ${token}`
            }
         })
    },
}