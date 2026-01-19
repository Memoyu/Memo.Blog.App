<script setup lang="ts">
const route = useRoute();
const router = useRouter();

const props = defineProps({
  title: {
    type: String,
    default: "",
  },
  showTitle: {
    type: Boolean,
    default: true,
  },
});

const navTitle = ref();

function onBack() {
  if (window.history.state.back) history.back();
  else router.replace("/");
}

onMounted(() => {
  // console.log("onMounted title", props.title);
  navTitle.value = getNavTitle();
});

watch(
  () => props.title,
  () => {
    // console.log("nav title", props.title);
    navTitle.value = getNavTitle();
  },
);

function getNavTitle() {
  if (!props.showTitle) return "";
  // console.log("props title", props.title, !props.title);
  if (!props.title) return route.meta ? route.meta.title : "";
  return props.title;
}
</script>

<template>
  <van-nav-bar
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
  </van-nav-bar>
</template>

<style scoped lang="less">
.nav-bar-title {
  width: 150px;
}
</style>
