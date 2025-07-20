import { createApp } from "vue";

import router from '@/router';
import pinia from '@/stores';
import App from "./App.vue";

import 'vant/es/toast/style'

const app = createApp(App)

app.use(router);
app.use(pinia)
app.mount("#app");
