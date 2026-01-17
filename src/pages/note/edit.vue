<script setup lang="ts">
import api from "@/services/api";
import { Note } from "@/types/interfaces";

const route = useRoute();
const query = ref(route.query as { id: string });
const note = ref<Note>();

const content = ref();
const showOutline = ref(false);

onMounted(() => {
  // 获取笔记详情
  api.noteGet(query.value.id).then((res) => {
    note.value = res;
    content.value = res.content;
  });
});
</script>

<template>
  <nav-bar>
    <template #right>
      <div class="i-carbon-list" @click="showOutline = !showOutline" />
    </template>
  </nav-bar>
  <div>
    <md-editor
      v-model:content="content"
      v-model:show-outline="showOutline"
      v-if="content"
    />
  </div>
</template>

<style lang="less" scoped></style>

<route lang="json5">
{
  name: "NoteEdit",
  meta: {
    title: "编辑笔记",
  },
}
</route>
