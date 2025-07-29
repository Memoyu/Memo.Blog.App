<script setup lang="ts">
import { routeWhiteList } from "@/common/configs/routes";

const route = useRoute();
const router = useRouter();

function onBack() {
  if (window.history.state.back) history.back();
  else router.replace("/");
}

const title = computed(() => {
  if (!route.meta) return "";

  return route.meta.title || "";
});

const show = computed(() => route.name && routeWhiteList.includes(route.name));
</script>

<template>
  <VanNavBar
    v-if="!show"
    :title="title"
    :fixed="true"
    clickable
    placeholder
    :left-arrow="true"
    @click-left="onBack"
  />
</template>
