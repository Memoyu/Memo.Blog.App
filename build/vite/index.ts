import vue from "@vitejs/plugin-vue";
import AutoImport from "unplugin-auto-import/vite";
import { unheadVueComposablesImports } from "@unhead/vue";
import { VueRouterAutoImports } from "unplugin-vue-router";
import Components from "unplugin-vue-components/vite";
import { VantResolver } from "unplugin-vue-components/resolvers";
import VueRouter from "unplugin-vue-router/vite";
import UnoCSS from "unocss/vite";
import { createViteVConsole } from "./vconsole";

export function createVitePlugins(mode: string) {
  return [
    [
      VueRouter({
        extensions: [".vue"],
        routesFolder: "src/pages",
        dts: "src/types/typed-router.d.ts",
      }),

      vue(),

      Components({
        extensions: ["vue"],
        resolvers: [VantResolver()],
        include: [/\.vue$/, /\.vue\?vue/],
        dts: "src/types/components.d.ts",
      }),

      AutoImport({
        include: [/\.[tj]sx?$/, /\.vue$/, /\.vue\?vue/],
        imports: [
          "vue",
          "@vueuse/core",
          VueRouterAutoImports,
          {
            "vue-router/auto": ["useLink"],
            "@/utils/i18n": ["i18n", "locale"],
            "vue-i18n": ["useI18n"],
          },
          unheadVueComposablesImports,
        ],
        dts: "src/types/auto-imports.d.ts",
        dirs: ["src/composables"],
        resolvers: [VantResolver()],
      }),

      UnoCSS(),

      createViteVConsole(mode),
    ],
  ];
}
