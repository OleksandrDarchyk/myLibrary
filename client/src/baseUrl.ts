const isPoduction = import.meta.env.PROD;

const prod =  "https://server-bold-hill-5068.fly.dev/"
const dev = "http://localhost:5173/"

export const finalUrl = isPoduction ? prod : dev;