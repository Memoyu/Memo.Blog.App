<script setup lang="ts">
import api from "@/services/api";
import { NoteCatalogItem } from "@/types/interfaces";

const show = defineModel<boolean>();
const emit = defineEmits(["confirm", "cancel"]);

const loading = ref(false);

const catalogs = ref<any>({});
const currentCatalog = ref<NoteCatalogItem>();
const catalogHistory = ref<NoteCatalogItem[]>([]);

watch(
  () => show.value,
  (show) => {
    if (!show) return;

    loading.value = true;
    // 获取分组目录列表
    api
      .catalogList(true)
      .then((res) => {
        catalogs.value = res;
      })
      .finally(() => {
        loading.value = false;
      });
  },
);

function onBackClick() {
  if (catalogHistory.value.length < 1) {
    return;
  }

  // 移除最后一个历史记录
  catalogHistory.value.pop();
  const last = catalogHistory.value[catalogHistory.value.length - 1];
  currentCatalog.value = last;
}

function onRootClick() {
  currentCatalog.value = undefined;
  // 清空历史记录
  catalogHistory.value = [];
}

function onCatalogHistoryClick(index: number, item: NoteCatalogItem) {
  currentCatalog.value = item;
  // 截取历史记录
  catalogHistory.value = catalogHistory.value.slice(0, index + 1);
}

function onConfirmClick() {
  emit("confirm", currentCatalog.value);
}
function onCancelClick() {
  show.value = false;
  emit("cancel");
}

function onCatalogClick(item: NoteCatalogItem) {
  currentCatalog.value = item;
  catalogHistory.value.push(item);
}
</script>

<template>
  <center-popup
    v-model="show"
    :coco="false"
    @confirm="onConfirmClick"
    @cancel="onCancelClick"
    width="90%"
  >
    <div class="relative overflow-y-scroll" style="height: 300px">
      <div class="select-breadcrumb-box">
        <div class="select-selected-catalog">
          {{ currentCatalog?.title ?? "" }}
        </div>
        <div class="select-breadcrumb">
          <van-icon
            name="arrow-left"
            size="25"
            class="pr-8"
            @click="onBackClick"
          />
          <div class="select-breadcrumb-item mr-12" @click="onRootClick">
            Root
          </div>
          <div class="flex items-center overflow-scroll">
            <div class="flex" v-for="(item, index) in catalogHistory">
              <div
                class="select-breadcrumb-item whitespace-nowrap"
                @click="() => onCatalogHistoryClick(index, item)"
              >
                {{ item.title }}
              </div>
              <div class="mx-6" v-if="index < catalogHistory.length - 1">/</div>
            </div>
          </div>
        </div>
      </div>
      <van-list v-model:loading="loading" :finished="true">
        <list-card
          v-for="item in catalogs[currentCatalog?.id ?? ''] ?? []"
          :key="item.id"
        >
          <van-row
            gutter="10"
            class="select-catalog-box"
            @click="() => onCatalogClick(item)"
          >
            <van-col span="2">
              <div
                :size="19"
                class="i-carbon-folder"
                :style="{ color: 'rgb(214, 150, 97)', marginRight: '9px' }"
              />
            </van-col>
            <van-col span="19">
              <van-text-ellipsis :content="item.title" />
            </van-col>
            <van-col span="3">
              <div class="select-catalog-count">
                {{ item.count }}
              </div>
            </van-col>
          </van-row>
        </list-card>
      </van-list>
    </div>
  </center-popup>
</template>

<style lang="less" scoped>
.select-breadcrumb-box {
  position: sticky;
  top: 0;
  z-index: 3;
  padding-bottom: 8px;
  background: var(--van-background-2);
}

.select-selected-catalog {
  position: relative;
  top: 0;
  z-index: 3;
  background: var(--van-background-2);
  text-align: center;
  height: 16px;
  font-size: 16px;
  font-weight: bold;
  margin-bottom: 13px;
}

.select-breadcrumb {
  --at-apply: flex items-center;
}

.select-breadcrumb-item {
  color: var(--van-primary-color);
}
.select-catalog-box {
  align-items: center;
}
.select-catalog-count {
  margin-right: 20px;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 25px;
  height: 25px;
  border-radius: 50%;
  background-color: var(--van-background);
}
</style>
