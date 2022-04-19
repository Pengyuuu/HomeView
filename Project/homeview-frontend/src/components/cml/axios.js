import axios from "axios";

const instance = axios.create({
    baseURL: "https://streaming-availability.p.rapidapi.com",

});
export default instance;