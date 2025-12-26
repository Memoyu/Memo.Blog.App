<script setup lang="ts">
import api from "@/services/api";
import { Config } from "@/types/interfaces";
import type { CollapseInstance } from "vant";

const bannerMap = {
  home: "首页",
  article: "文章",
  lab: "实验室",
  moment: "动态",
  about: "关于",
};

const activeName = ref([]);
const collapseRef = ref<CollapseInstance>();
const config = ref<Config>();

onMounted(() => {
  api.configGet().then((res) => {
    config.value = res;
  });
  collapseRef.value?.toggleAll();
});
</script>

<template>
  <van-collapse v-model="activeName" ref="collapseRef">
    <van-collapse-item title="头图配置">
      <van-list>
        <list-card v-for="(item, key) in config?.banner" :key="key">
          <div>
            <div>{{ bannerMap[key] }}</div>
            <van-image height="150" fit="contain" :src="item.url" />
            <van-field
              v-model="item.title"
              label="来源"
              placeholder="图片来源"
            />
            <van-field
              v-model="item.originUrl"
              label="链接"
              placeholder="来源链接"
            />
          </div>
        </list-card>
      </van-list>
    </van-collapse-item>
  </van-collapse>
</template>

<style lang="less" scoped>
:deep(.van-collapse-item__content) {
  padding: 0;
  background: var(--van-background);
}
</style>

<route lang="json5">
{
  name: "Config",
  meta: {
    title: "系统配置",
  },
}
</route>
