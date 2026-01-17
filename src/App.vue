<script setup lang="ts">
import { useRouteCacheStore } from "@/stores";

const routeCacheStore = useRouteCacheStore();

const keepAliveRouteNames = computed(() => {
  return routeCacheStore.routeCaches;
});

const mode = computed(() => {
  return isDark.value ? "dark" : "light";
});

onMounted(() => {
  initThemeMode();
});

function initThemeMode() {}
</script>

<template>
  <van-config-provider :theme="mode">
    <router-view v-slot="{ Component }">
      <section class="app-wrapper">
        <keep-alive :include="keepAliveRouteNames">
          <component :is="Component" />
        </keep-alive>
      </section>
    </router-view>
    <tab-bar />
  </van-config-provider>
</template>

<style scoped>
.app-wrapper {
  width: 100%;
  position: relative;
  padding: 16px;
}
</style>
