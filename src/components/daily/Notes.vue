<script setup lang="ts">
import api from "@/services/api";
import { NoteCatalogItem } from "@/types/interfaces";
import router from "@/router";
import { showToast } from "vant";

const defPopupGrids = [
  { title: "新建笔记", icon: "i-carbon-document-blank", action: addNote },
  {
    title: "新建分组",
    icon: "i-carbon-document-multiple-01",
    action: addGroup,
  },
  { title: "编辑笔记", icon: "i-carbon-edit", action: editNote },
];

const loading = ref(false);
const finished = ref(true);

const showSet = ref(false);
const showSetCell = ref(false);
const showEditTitle = ref(false);
const isRename = ref(false);

const search = ref("");
const catalogs = ref<any>({});
const currentCatalog = ref<NoteCatalogItem>();
const catalogHistory = ref<NoteCatalogItem[]>([]);

const setCatalogItem = ref<NoteCatalogItem>();
const popupGrids = ref(defPopupGrids);
const inputTitle = ref("");

defineExpose({
  addClick,
});

onMounted(() => {
  // 获取笔记目录列表
  api.catalogList().then((res) => {
    catalogs.value = res;
  });
});

function isGroup(type?: number) {
  return type === 0;
}

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

function onNoteGroupClick(item: NoteCatalogItem) {
  if (!isGroup(item.type)) {
    // 是笔记时，跳转笔记页面
    router.push({ name: "NotePreview", query: { id: item.id } });
    return;
  }
  currentCatalog.value = item;
  catalogHistory.value.push(item);
}

function onNoteGroupSetClick(e: MouseEvent, item: NoteCatalogItem) {
  e.stopPropagation();
  setCatalogItem.value = item;
  showSet.value = true;
  showSetCell.value = true;
  if (isGroup(item.type)) {
    popupGrids.value = defPopupGrids.slice(0, 2);
  } else {
    popupGrids.value = defPopupGrids;
  }
}

function addClick() {
  // console.log("新增笔记");
  showSet.value = true;
  showSetCell.value = false;
  // 不会存在[编辑笔记]
  popupGrids.value = defPopupGrids.slice(0, 2);
}

function addNote() {
  // console.log("新增笔记");
  showSet.value = false;
  // console.log(setCatalogItem.value);

  // 判断当前操作的是否为分组
  var groupId = setCatalogItem.value?.id;
  if (!isGroup(setCatalogItem.value?.type)) {
    // 否则为当前分组
    groupId = currentCatalog.value?.id ?? "";
  }
  router.push({
    name: "NoteEdit",
    query: { groupId: groupId },
  });
}

function addGroup() {
  // console.log("新增分组");
  showSet.value = false;
  showEditTitle.value = true;
  isRename.value = false;
}

function confirmEditTitleClick() {
  if (!inputTitle.value || inputTitle.value.length < 1) {
    showToast("标题不能为空");
    return;
  }

  // console.log("标题", newGroupTitle.value);
  showEditTitle.value = false;
  if (isRename.value) {
    // 重命名
    api
      .titleUpdate({
        Id: setCatalogItem.value?.id ?? "",
        type: setCatalogItem.value?.type ?? 0,
        title: inputTitle.value,
      })
      .then(() => {
        setCatalogItem.value!.title = inputTitle.value;
        showToast("修改成功");
      });
  } else {
  }
}

function editNote() {
  showSet.value = false;
  if (!setCatalogItem.value) return;
  router.push({ name: "NoteEdit", query: { id: setCatalogItem.value.id } });
}

function onRenameTitleClick() {
  isRename.value = true;
  showSet.value = false;
  showEditTitle.value = true;
  inputTitle.value = setCatalogItem.value?.title ?? "";
}
</script>

<template>
  <div class="flex items-center my-15">
    <van-icon name="arrow-left" size="25" class="pr-8" @click="onBackClick" />
    <div class="breadcrumb-item mr-12" @click="onRootClick">Root</div>
    <div class="breadcrumb-box flex items-center overflow-scroll">
      <div class="flex" v-for="(item, index) in catalogHistory">
        <div
          class="breadcrumb-item whitespace-nowrap"
          @click="() => onCatalogHistoryClick(index, item)"
        >
          {{ item.title }}
        </div>
        <div class="mx-6" v-if="index < catalogHistory.length - 1">/</div>
      </div>
    </div>
  </div>
  <van-list v-model:loading="loading" :finished="finished">
    <list-card
      v-for="item in catalogs[currentCatalog?.id ?? ''] ?? []"
      :key="item.id"
    >
      <van-row
        gutter="10"
        class="catalog-box"
        @click="() => onNoteGroupClick(item)"
      >
        <van-col span="2" v-if="isGroup(item.type)">
          <div
            :size="19"
            class="i-carbon-folder catalog-icon"
            :style="{ color: 'rgb(214, 150, 97)', marginRight: '9px' }"
          />
        </van-col>
        <van-col :span="isGroup(item.type) ? 16 : 21">
          <van-text-ellipsis class="catalog-title" :content="item.title" />
        </van-col>
        <van-col :span="isGroup(item.type) ? 6 : 3">
          <div class="flex items-center float-right">
            <div v-if="isGroup(item.type)" class="catalog-count">
              {{ item.count }}
            </div>
            <div @click="(e) => onNoteGroupSetClick(e, item)">
              <van-icon name="ellipsis" size="25" />
            </div>
          </div>
        </van-col>
      </van-row>
    </list-card>
  </van-list>

  <bottom-popup
    v-model:show="showSet"
    :show-confirm="false"
    @cancel="showSet = false"
  >
    <van-row :gutter="10">
      <van-col span="6" v-for="g in popupGrids" @click="g.action">
        <div class="popup-grid-item">
          <div :class="g.icon" class="grid-item-icon"></div>
          <div class="mt-11">{{ g.title }}</div>
        </div>
      </van-col>
    </van-row>
    <div class="popup-cell-box" v-if="showSetCell">
      <van-cell title="重命名" @click="onRenameTitleClick">
        <template #right-icon>
          <van-icon name="more-o" />
        </template>
      </van-cell>
      <van-cell title="删除" :title-style="{ color: 'red' }">
        <template #right-icon>
          <van-icon name="delete-o" color="red" />
        </template>
      </van-cell>
    </div>
  </bottom-popup>

  <center-popup
    v-model="showEditTitle"
    :coco="false"
    :title="isRename ? '重命名' : '新建分组'"
    @confirm="confirmEditTitleClick"
    @cancel="showEditTitle = false"
  >
    <van-field
      v-model="inputTitle"
      :placeholder="
        !setCatalogItem || isGroup(setCatalogItem?.type)
          ? '请输入分组名称'
          : '请输入笔记标题'
      "
    />
  </center-popup>
</template>

<style lang="less" scoped>
:deep(.van-cell) {
  background: var(--van-background);
}

.breadcrumb-item {
  color: var(--van-primary-color);
}
.catalog-box {
  align-items: center;
}

.catalog-icon {
}

.catalog-title {
  width: 100%;
}

.catalog-count {
  margin-right: 20px;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 25px;
  height: 25px;
  border-radius: 50%;
  background-color: var(--van-background-2);
}

.popup-grid-item {
  padding: 12px 9px;
  font-size: var(--van-cell-font-size);
  border-radius: 8px;
  background: var(--van-background);
  --at-apply: flex flex-col items-center;
}
.grid-item-icon {
  font-size: 23px;
}
.popup-cell-box {
  margin-top: 15px;
  overflow: hidden;
  border-radius: 8px;
}
</style>
