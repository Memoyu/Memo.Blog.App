<script setup lang="ts">
import router from "@/router";

const fs = [
  {
    title: "友链",
    icon: "i-carbon:direct-link",
    name: "FriendlyLink",
  },
  {
    title: "开源",
    icon: "i-carbon:ibm-watson-openscale",
    name: "OpenSource",
  },
  {
    title: "用户",
    icon: "i-carbon:user-multiple",
    name: "User",
  },
  {
    title: "权限&角色",
    icon: "i-carbon:user-role",
    name: "Permission",
  },
  {
    title: "日志",
    icon: "i-carbon:document",
    name: "Logging",
  },
  {
    title: "系统配置",
    icon: "i-carbon:settings-view",
    name: "Config",
  },
  {
    title: "设置",
    icon: "i-carbon:settings",
    name: "Setting",
  },
];

function toPage(name: any) {
  router.push({ name: name });
}
</script>

<template>
  <div class="grid grid-cols-2 gap-10 mt-20">
    <div
      class="func-item"
      v-for="f in fs"
      :key="f.title"
      @click="() => toPage(f.name)"
    >
      <div class="flex items-center">
        <div :class="f.icon" style="font-size: 18px" />
        <div class="func-title">{{ f.title }}</div>
      </div>
    </div>
  </div>
</template>

<style lang="less" scoped>
.func-item {
  padding: 12px 15px;
  border-radius: 6px;
  background: var(--van-background-2);
}

.func-title {
  margin-left: 18px;
}
</style>
