import {http} from "./config"
//import usuario from "../store/modules/usuario"

export default {
    logar:(usu) => {
        return http.post('autenticacao/login',usu)
    },
    criar:(usu) => {
        return http.post('autenticacao/register',usu)
    }
}