import {http} from "./config"
//import usuario from "../store/modules/usuario"

export default {
    home:(token) => {
        return axios.get("usuario/home", {
            headers: {
               Authorization: 'Bearer ' + token,
            }
         })
    },
    logar:(usu) => {
        return http.post('autenticacao/login',usu)
    },
    criar:(usu) => {
        return http.post('autenticacao/register',usu)
    }
}