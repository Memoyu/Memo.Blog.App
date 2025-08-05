import { createPinia } from "pinia";
import piniaPluginPersistedstate from "pinia-plugin-persistedstate";

import useAuthTokenStore from "./modules/auth";
import useUserStore from "./modules/user";
import useRouteCacheStore from "./modules/routeCache";

const pinia = createPinia();
pinia.use(piniaPluginPersistedstate);

export { useAuthTokenStore, useUserStore, useRouteCacheStore };
export default pinia;
