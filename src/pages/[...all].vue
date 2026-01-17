<script setup lang="ts">
const router = useRouter();

function onBack() {
  if (window.history.state.back) history.back();
  else router.replace("/");
}
</script>

<template>
  <nav-bar />
  <div text="center gray-300 dark:gray-200">
    <van-empty image="error" description="页面不存在" />

    <div class="mt-10">
      <ghost-button @click="onBack">返回</ghost-button>
    </div>
  </div>
</template>

<route lang="json5">
{
  name: "404",
}
</route>
