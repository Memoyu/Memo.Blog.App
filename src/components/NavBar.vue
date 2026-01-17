<script setup lang="ts">
const route = useRoute();
const router = useRouter();

const props = defineProps({
  title: {
    type: String,
  },
});

function onBack() {
  if (window.history.state.back) history.back();
  else router.replace("/");
}

const navTitle = computed(() => {
  if (!props.title) return route.meta ? route.meta.title : "";
  return props.title;
});
</script>

<template>
  <VanNavBar
    :fixed="true"
    clickable
    placeholder
    :left-arrow="true"
    @click-left="onBack"
  >
    <template #title>
      <van-text-ellipsis class="nav-bar-title" :content="navTitle" />
    </template>
    <template #right>
      <slot name="right"></slot>
    </template>
  </VanNavBar>
</template>

<style scoped lang="less">
.nav-bar-title {
  width: 150px;
}
</style>
