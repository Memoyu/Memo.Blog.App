<script setup lang="ts">
import Vditor from "vditor";
import "vditor/dist/index.css";

const previewRef = ref<HTMLDivElement>();
const outlineRef = ref<Element>();

const content = defineModel<string>("content");
const showOutline = defineModel<boolean>("showOutline");

const mode = computed(() => {
  return isDark.value ? "dark" : "light";
});

watch(
  () => content.value,
  (text) => {
    Vditor.preview(previewRef.value as HTMLDivElement, text ?? "", {
      // cdn: "https://ld246.com/js/lib/vditor",
      mode: mode.value,
      anchor: 1,
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
      //lazyLoadImage: "//unpkg.com/vditor/dist/images/img-loading.svg",
      //   renderers: {
      //     renderHeading: (node, entering) => {
      //       const id = Lute.GetHeadingID(node);
      //       if (entering) {
      //         return [
      //           `<h${node.__internal_object__.HeadingLevel} id="${id}" class="vditor__heading"><span class="prefix"></span><span>`,
      //           Lute.WalkContinue,
      //         ];
      //       } else {
      //         return [
      //           `</span><a id="vditorAnchor-${id}" class="vditor-anchor" href="#${id}"><svg viewBox="0 0 16 16" version="1.1" width="16" height="16"><path fill-rule="evenodd" d="M4 9h1v1H4c-1.5 0-3-1.69-3-3.5S2.55 3 4 3h4c1.45 0 3 1.69 3 3.5 0 1.41-.91 2.72-2 3.25V8.59c.58-.45 1-1.27 1-2.09C10 5.22 8.98 4 8 4H4c-.98 0-2 1.22-2 2.5S3 9 4 9zm9-3h-1v1h1c1 0 2 1.22 2 2.5S13.98 12 13 12H9c-.98 0-2-1.22-2-2.5 0-.83.42-1.64 1-2.09V6.25c-1.09.53-2 1.84-2 3.25C6 11.31 7.55 13 9 13h4c1.45 0 3-1.69 3-3.5S14.5 6 13 6z"></path></svg></a></h${node.__internal_object__.HeadingLevel}>`,
      //           Lute.WalkContinue,
      //         ];
      //       }
      //     },
      //   },
    });
  },
);

function onOutlineOpened() {
  const previewElem = previewRef.value as HTMLDivElement;
  var outlineElem = outlineRef.value as HTMLDivElement;
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
