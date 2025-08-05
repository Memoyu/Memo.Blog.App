import {
  createRouter,
  createWebHistory,
  NavigationGuardNext,
} from "vue-router";
import { handleHotUpdate, routes } from "vue-router/auto-routes";

import NProgress from "nprogress";
import "nprogress/nprogress.css";

import type { EnhancedRouteLocation } from "./types";
import { useAuthTokenStore, useRouteCacheStore, useUserStore } from "@/stores";

import { setPageTitle } from "@/utils/document";
import { PageEnum } from "@/common/enums";

NProgress.configure({ showSpinner: true, parent: "#app" });

const whitePathList = [PageEnum.LOGIN.toString()];

const router = createRouter({
  history: createWebHistory(import.meta.env.VITE_APP_PUBLIC_PATH),
  routes,
});

// This will update routes at runtime without reloading the page
if (import.meta.hot) handleHotUpdate(router);

router.beforeEach(
  async (
    to: EnhancedRouteLocation,
    from: EnhancedRouteLocation,
    next: NavigationGuardNext,
  ) => {
    NProgress.start();

    const routeCacheStore = useRouteCacheStore();
    const authTokenStore = useAuthTokenStore();
    const userStore = useUserStore();

    // Route cache
    routeCacheStore.addRoute(to);

    // Set page title
    setPageTitle(to.meta.title);

    // Whitelist can be directly entered
    if (whitePathList.includes(to.path as PageEnum)) {
      next();
      return;
    }

    if (!authTokenStore.isLogin()) {
      // redirect login page
      next(PageEnum.LOGIN);
      return;
    }

    if (authTokenStore.isLogin() && !userStore.userInfo?.userId)
      await userStore.info();

    next();
  },
);

router.afterEach(() => {
  NProgress.done();
});

export default router;
