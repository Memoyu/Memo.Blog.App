import { appName } from '@/common/constants'

function setPageTitle(title?: string): void {
  window.document.title = title ? `${title} - ${appName}` : appName
}


export { setPageTitle }
