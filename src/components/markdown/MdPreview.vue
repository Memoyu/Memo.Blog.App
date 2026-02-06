<script setup lang="ts">
import Vditor from "vditor";
import "vditor/dist/index.css";

const props = defineProps<{
  content: string;
}>();
const showOutline = defineModel<boolean>("showOutline");

const previewRef = ref<HTMLDivElement>();
const outlineRef = ref<Element>();
const rendering = ref(false);
const renderQueue = ref<string[]>([]);

const mode = computed(() => {
  return isDark.value ? "dark" : "light";
});

onMounted(() => {
  console.log("初始");
  RenderMarkdown(props.content);
});

watch(
  () => props.content,
  (text) => {
    console.log("变化");
    RenderMarkdown(text);
  },
);

// 渲染Markdown
function RenderMarkdown(text: string) {
  if (rendering.value) {
    renderQueue.value.push(text);
    return;
  }

  rendering.value = true;
  Vditor.preview(previewRef.value as HTMLDivElement, text ?? "", {
    mode: mode.value,
    hljs: {
      lineNumber: true,
      style: "github",
    },
    math: {
      inlineDigit: true,
      macros: {},
    },
    theme: {
      current: mode.value,
    },
    after() {
      console.log("渲染完成");
      rendering.value = false;
      const text = renderQueue.value.shift();
      if (text) {
        RenderMarkdown(text);
        return;
      }
    },
  });
}

function onOutlineOpened() {
  const previewElem = previewRef.value as HTMLDivElement;
  var outlineElem = outlineRef.value as HTMLDivElement;
  console.log(previewElem);
  Vditor.outlineRender(previewElem, outlineElem);
  if (outlineElem.innerText.trim() !== "") {
    outlineElem.style.display = "block";
    initOutline(outlineElem);
  }
}

const initOutline = (outlineElem: HTMLElement) => {
  outlineElem.firstElementChild!.addEventListener("click", (event: Event) => {
    let target = event.target as HTMLElement;
    if (!target.classList.contains("vditor-outline__action")) {
      // console.log("点击节点");
      showOutline.value = false;
    }
  });
};
</script>

<template>
  <div>
    <div class="vditor-preview-container">
      <div ref="previewRef"></div>
    </div>
    <van-popup
      v-model:show="showOutline"
      round
      position="bottom"
      :style="{ height: '40%' }"
      @opened="onOutlineOpened"
    >
      <div class="vditor-outline-container">
        <div class="vditor-outline-title">大纲</div>
        <div ref="outlineRef"></div>
      </div>
    </van-popup>
  </div>
</template>

<style lang="less" scoped>
:deep(.vditor-outline__action) {
  height: 14px;
  width: 14px;
}

.vditor-preview-container {
  padding: 8px;
}

.vditor-outline-container {
  margin: 10px 0;
}

.vditor-outline-title {
  font-size: var(--van-font-size-lg);
  --at-apply: flex justify-center font-bold;
}
</style>
