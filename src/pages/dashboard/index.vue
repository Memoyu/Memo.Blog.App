<script setup lang="ts">
import router from "@/router";
import { useUserStore } from "@/stores";

const userStore = useUserStore();
const userInfo = computed(() => userStore.userInfo);

function login() {
  router.push({ name: "Login", query: { redirect: "Profile" } });
}
</script>
<template>
  <statistics />
  <ranking />
  <visitor-map />
</template>

<route lang="json5">
{
  name: "Dashboard",
  path: "/",
  meta: {
    title: "概览",
  },
}
</route>
