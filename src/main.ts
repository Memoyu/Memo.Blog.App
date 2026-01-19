import { createApp } from "vue";
import { createHead } from "@unhead/vue/client";
import "virtual:svg-icons-register";

import router from "@/router";
import pinia from "@/stores";
import App from "./App.vue";

import "virtual:uno.css";
import "vant/es/toast/style";
import "vant/es/dialog/style";
import "vant/es/notify/style";
import "vant/es/image-preview/style";

import "@/styles/app.less";
import "@/styles/var.less";

const app = createApp(App);

const head = createHead();
app.use(head);
app.use(router);
app.use(pinia);
app.mount("#app");
