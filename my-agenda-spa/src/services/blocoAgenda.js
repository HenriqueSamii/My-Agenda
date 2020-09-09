import {http} from "./config"

export default {
    home:(token) => {
        return http.get("BlocoDaAgenda/home", {
            headers: {
               'Authorization': 'Bearer ' + token,
            }
         })
    },
}