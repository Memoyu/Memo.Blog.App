import type { ConfigEnv, UserConfig } from "vite";
import path from "node:path";
import { createVitePlugins } from "./build/vite";

const host = process.env.TAURI_DEV_HOST;

// https://vitejs.dev/config/
export default ({ mode }: ConfigEnv): UserConfig => {
  return {
    plugins: createVitePlugins(mode),

    // Vite options tailored for Tauri development and only applied in `tauri dev` or `tauri build`
    //
    // 1. prevent vite from obscuring rust errors
    clearScreen: false,
    // 2. tauri expects a fixed port, fail if that port is not available
    server: {
      port: 11013,
      strictPort: true,
      host: host || false,
      hmr: host
        ? {
            protocol: "ws",
            host,
            port: 1421,
          }
        : undefined,
      watch: {
        // 3. tell vite to ignore watching `src-tauri`
        ignored: ["**/src-tauri/**"],
      },
    },

    resolve: {
      alias: {
        "@": path.join(__dirname, "./src"),
        "~": path.join(__dirname, "./src/assets"),
        "~root": path.join(__dirname, "."),
      },
    },
    optimizeDeps: {
      include: [
        "axios",
        "lodash-es",
        "vant/es",
        "vant/es/cell-group/style/index",
        "vant/es/popup/style/index",
        "vant/es/picker/style/index",
        "vant/es/cell/style/index",
        "vant/es/switch/style/index",
        "vant/es/space/style/index",
        "vant/es/button/style/index",
        "vant/es/empty/style/index",
        "vant/es/icon/style/index",
        "vant/es/stepper/style/index",
        "vant/es/image/style/index",
        "vant/es/form/style/index",
        "vant/es/field/style/index",
        "vant/es/notify/style/index",
        "vant/es/config-provider/style/index",
        "vant/es/nav-bar/style/index",
        "vant/es/tabbar/style/index",
        "vant/es/tabbar-item/style/index",
        "vant/es/list/style/index",
        "vant/es/text-ellipsis/style/index",
        "unplugin-vue-router/runtime",
        "unplugin-vue-router/data-loaders",
        "unplugin-vue-router/data-loaders/basic",
      ],
      exclude: ["@iconify-json/carbon"],
    },
  };
};
