import { APP_NAME } from "@/common/constants";

function setPageTitle(title?: string): void {
  window.document.title = title ? `${title} - ${APP_NAME}` : APP_NAME;
}

export { setPageTitle };
