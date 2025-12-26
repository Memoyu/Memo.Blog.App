export interface Config {
  color: ColorConfig;
  banner: BannerConfig;
}

export interface ColorConfig {
  primary: Array<string>;
  secondary: Array<string>;
  tertiary: Array<string>;
}

export interface BannerConfig {
  home: BannerItem;
  article: BannerItem;
  lab: BannerItem;
  moment: BannerItem;
  about: BannerItem;
}

export interface BannerItem {
  url?: string;
  title?: string;
  originUrl?: string;
}

export interface ConfigEditBannerRequest {
  banner: BannerConfig;
}
