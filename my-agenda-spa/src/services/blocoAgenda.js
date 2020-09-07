import {http} from "./config"

export default {
    home:(token) => {
        return axios.get("BlocoDaAgenda/home", {
            headers: {
               Authorization: 'Bearer ' + token,
            }
         })
    },
}