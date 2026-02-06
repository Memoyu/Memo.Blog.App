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
      <div class="nav-bar-right">
        <slot name="right"></slot>
      </div>
    </template>
  </van-nav-bar>
</template>

<style scoped lang="less">
.nav-bar-title {
  width: 150px;
}

:deep(.van-nav-bar__right) {
  padding: 0;
}

.nav-bar-right {
  :deep(.van-icon) {
    font-size: 16px;
    padding: 0 var(--van-padding-md);
  }
}
</style>
