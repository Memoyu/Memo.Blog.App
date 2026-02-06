<script setup lang="ts">
import api from "@/services/api";
import { Note } from "@/types/interfaces";
import { closeToast, showLoadingToast, showToast } from "vant";

const route = useRoute();
const query = ref(route.query as { id: string; groupId: string });

const mdEditorRef = ref();
const noteTitlRef = ref();

const loadEditor = ref<boolean>(true);

const note = ref<Note>();
const noteId = ref(query.value.id);
const title = ref("");
const content = ref("");
const showOutline = ref(false);

onMounted(() => {
  showLoadingToast({
    duration: 10,
    forbidClick: true,
    message: "加载中...",
  });
  // 传入id则获取详情
  if (noteId.value) {
    // 获取笔记详情
    api.noteGet(noteId.value).then((res) => {
      note.value = res;
      title.value = res.title;
      content.value = res.content;

      // 标题栏获取焦点，使其重算高度
      nextTick(() => noteTitlRef.value.focus());
    });
  }
});

watch(
  () => loadEditor,
  (loading) => {
    if (!loading) closeToast();
  },
);

function onSaveClick() {
  if (!title.value) {
    showToast("请输入标题");
    return;
  }

  const content = mdEditorRef.value.getContent();
  showLoadingToast({
    duration: 10,
    forbidClick: true,
    message: "保存中...",
  });
  var save;
  if (note.value) {
    // 更新
    save = api.noteUpdate({
      noteId: noteId.value,
      groupId: note.value.group?.groupId,
      title: title.value,
      content: content,
    });
  } else {
    // 新增
    const groupId = query.value.groupId ?? "";
    save = api.noteCreate({
      groupId: groupId,
      title: title.value,
      content: content,
    });
  }

  save
    .then((res) => {
      closeToast();
      showToast("保存成功");
    })
    .catch((err) => {
      closeToast();
      showToast(`保存失败：${err.message}`);
    });
}
function onOutlineClick() {
  showOutline.value = true;
}
function onMoreClick() {}
</script>

<template>
  <nav-bar :show-title="false">
    <template #right>
      <div class="flex items-center">
        <van-icon name="success" @click.stop="onSaveClick" />
        <van-icon class="i-carbon-list" @click.stop="onOutlineClick" />
        <van-icon name="ellipsis" @click.stop="onMoreClick" />
      </div>
    </template>
  </nav-bar>
  <div class="note-container">
    <div class="note-title">
      <van-field
        ref="noteTitlRef"
        v-model="title"
        rows="1"
        autosize
        type="textarea"
        placeholder="请输入标题"
      />
    </div>
    <div class="mb-60">
      <md-editor
        ref="mdEditorRef"
        v-model:loading="loadEditor"
        v-model:content="content"
        v-model:show-outline="showOutline"
      />
    </div>
  </div>
</template>

<style lang="less" scoped>
.nav-bar-right-icon {
  padding: 0 var(--van-padding-md);
}

.note-title {
  :deep(.van-cell) {
    background: var(--van-background);
    font-size: 1.75em;
    font-weight: 600;
    line-height: 1.25;
    padding: 0;
  }
  :deep(.van-cell::after) {
    border: none;
  }

  --at-apply: mb-18;
}
</style>

<route lang="json5">
{
  name: "NoteEdit",
  meta: {
    title: "编辑笔记",
  },
}
</route>
