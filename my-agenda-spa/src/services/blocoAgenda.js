import {localhost} from "./config"
import axios from 'axios'

export default {
    home:(token) => {
        return axios.get(localhost+"BlocoDaAgenda/home", {
            headers: {
               Authorization: `Bearer ${token}`
            }
         })
    },
}