<script setup lang="ts">
import api from "@/services/api";
import { PermissionListItem } from "@/types/interfaces";

const search = ref("");
const activeName = ref([]);
const perGroups = ref<Record<string, PermissionListItem[]>>();

onMounted(() => {
  // 获取权限分组列表
  getPermissions();
});

function onSearch(text?: string) {
  getPermissions(text);
}

function getPermissions(text?: string) {
  api.permissionList(text).then((pers) => {
    // 分组数据
    perGroups.value = pers.reduce(
      (group, per) => {
        const { moduleName } = per;
        group[moduleName] = group[moduleName] ?? [];
        group[moduleName].push(per);
        return group;
      },
      {} as Record<string, PermissionListItem[]>,
    );
  });
}
</script>

<template>
  <van-search
    v-model="search"
    placeholder="请输入搜索关键词"
    @search="onSearch"
  />
  <van-collapse v-model="activeName">
    <van-collapse-item v-for="(items, key) in perGroups" :key="key">
      <template #title>
        <div class="flex">
          <div class="mr-20">{{ key }}</div>
        </div>
      </template>
      <van-list>
        <list-card
          class="friend-item"
          v-for="per in items"
          :key="per.permissionId"
        >
          <div>
            <div class="">
              <div class="per-name">{{ per.name }}</div>
              <div class="">{{ per.signature }}</div>
            </div>
            <div class="mt-10 flex space-x-20">
              <van-tag
                color="#7232dd"
                size="medium"
                v-for="r in per.roles"
                :key="per.permissionId"
              >
                {{ r.name }}
              </van-tag>
            </div>
          </div>
        </list-card>
      </van-list>
    </van-collapse-item>
  </van-collapse>
</template>

<style lang="less" scoped>
.per-name {
  color: var(--van-text-color);
  font-weight: var(--van-font-bold);
}
.per-desc {
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}
</style>
