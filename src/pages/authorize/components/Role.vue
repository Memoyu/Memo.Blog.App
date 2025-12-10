<script setup lang="ts">
import api from "@/services/api";
import { UserRole } from "@/types/interfaces";
import { TreeSelectItem } from "vant";

const search = ref("");
const activeName = ref("");

const roles = ref<UserRole[]>([]);

const mainActiveId = ref("");
const perActiveIds = ref<string[]>([]);
const perGroups = ref<TreeSelectItem[]>([]);

// 权限加载
const perLoading = ref(false);

onMounted(() => {
  // 获取友链列表
  getRoles("");
});
function onSearch(text: string) {
  getRoles(text);
}

function getRoles(text: string) {
  api.roleList(text).then((res) => {
    roles.value = res;
  });
}

function onChangeRole(id: string) {
  if (!id) return;
  perLoading.value = true;
  api
    .roleGet(id)
    .then((role) => {
      api.permissionGroup().then((group) => {
        perActiveIds.value = role.permissions.map((item) => item.permissionId);
        perGroups.value = group.map((g) => ({
          text: g.moduleName,
          children: g.permissions.map((p) => ({
            id: p.permissionId,
            text: p.name,
          })),
        }));
      });
    })
    .finally(() => {
      perLoading.value = false;
    });
}

function onClickPerNav(id: string) {
  console.log(id);
}
</script>

<template>
  <van-search
    v-model="search"
    placeholder="请输入搜索关键词"
    @search="onSearch"
  />
  <van-collapse v-model="activeName" accordion @change="onChangeRole">
    <van-collapse-item v-for="item in roles" :name="item.roleId">
      <template #title>
        <div class="flex">
          <div class="mr-20">{{ item.name }}</div>
          <van-text-ellipsis class="role-desc" :content="item.description" />
        </div>
      </template>
      <div v-if="perLoading"><van-loading size="24" /></div>
      <div v-else>
        <van-tree-select
          v-model:main-active-index="mainActiveId"
          v-model:active-id="perActiveIds"
          :items="perGroups"
          @click-nav="onClickPerNav"
        />
      </div>
    </van-collapse-item>
  </van-collapse>
</template>

<style lang="less" scoped>
.role-desc {
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}
</style>
