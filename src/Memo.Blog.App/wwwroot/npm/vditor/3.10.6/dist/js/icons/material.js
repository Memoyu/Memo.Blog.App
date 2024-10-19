﻿document.body.insertAdjacentHTML('afterBegin', `<svg style="position: absolute; width: 0; height: 0; overflow: hidden;" version="1.1" xmlns="http://www.w3.org/2000/svg">
  <defs>
    <symbol id="vditor-icon-comment" viewBox="0 0 32 32">
      <path d="M28.8 24.272l-1.872-1.872h-23.728v-19.2h25.6v21.072zM28.8 0h-25.6c-1.76 0-3.2 1.44-3.2 3.2v19.2c0 1.76 1.44 3.2 3.2 3.2h22.4l6.4 6.4v-28.8c0-1.76-1.44-3.2-3.2-3.2z"></path>
    </symbol>
    <symbol id="vditor-icon-headings" viewBox="0 0 32 32">
      <path d="M1.050 0.007h6.279v31.993h-6.279v-31.993z"></path>
      <path d="M24.671 0h6.279v31.993h-6.279v-31.993z"></path>
      <path d="M5.159 12.845h21.683v6.317h-21.683v-6.317z"></path>
    </symbol>
    <symbol id="vditor-icon-before" viewBox="0 0 32 32">
      <path d="M1.462 26.507h21.543v-3.276h-21.543v3.276z"></path>
      <path d="M1.462 9.928h16.48v-3.276h-16.48v3.276z"></path>
      <path d="M1.462 18.217h21.543v-3.276h-21.543v3.276z"></path>
      <path d="M24.366 8.29l6.171-5.952-2.43-2.338-8.619 8.29 8.619 8.29 2.43-2.337-6.171-5.953z"></path>
    </symbol>
    <symbol id="vditor-icon-after" viewBox="0 0 32 32">
      <path d="M1.462 5.493h21.543v3.276h-21.543v-3.276z"></path>
      <path d="M1.462 22.072h16.48v3.276h-16.48v-3.276z"></path>
      <path d="M1.462 13.783h21.543v3.276h-21.543v-3.276z"></path>
      <path d="M24.366 23.71l6.171 5.952-2.43 2.338-8.619-8.29 8.619-8.29 2.43 2.337-6.171 5.953z"></path>
    </symbol>
    <symbol id="vditor-icon-delete-column" viewBox="0 0 32 32">
      <path d="M5.279 0v23.265h3.538v-23.265h-3.538z"></path>
      <path d="M23.183 0v23.265h3.538v-23.265h-3.538z"></path>
      <path d="M14.231 0v17.797h3.538v-17.797h-3.538z"></path>
      <path d="M16 28.387l3.613 3.613 2.023-2.023-3.613-3.613 3.613-3.613-2.023-2.023-3.613 3.613-3.613-3.613-2.023 2.023 3.613 3.613-3.613 3.613 2.023 2.023 3.613-3.613z"></path>
    </symbol>
    <symbol id="vditor-icon-delete-row" viewBox="0 0 32 32">
      <path d="M0 5.279h23.265v3.538h-23.265v-3.538z"></path>
      <path d="M0 23.183h23.265v3.538h-23.265v-3.538z"></path>
      <path d="M0 14.231h17.797v3.538h-17.797v-3.538z"></path>
      <path d="M28.387 16l3.613 3.613-2.023 2.023-3.613-3.613-3.613 3.613-2.023-2.023 3.613-3.613-3.613-3.613 2.023-2.023 3.613 3.613 3.613-3.613 2.023 2.023-3.613 3.613z"></path>
    </symbol>
    <symbol id="vditor-icon-insert-row" viewBox="0 0 32 32">
      <path d="M1.462 5.493h21.543v3.276h-21.543v-3.276z"></path>
      <path d="M1.462 22.072h16.48v3.276h-16.48v-3.276z"></path>
      <path d="M1.462 13.783h21.543v3.276h-21.543v-3.276z"></path>
      <path d="M24.366 23.71l6.171 5.952-2.43 2.338-8.619-8.29 8.619-8.29 2.43 2.337-6.171 5.953z"></path>
    </symbol>
    <symbol id="vditor-icon-insert-rowb" viewBox="0 0 32 32">
      <path d="M1.462 26.507h21.543v-3.276h-21.543v3.276z"></path>
      <path d="M1.462 9.928h16.48v-3.276h-16.48v3.276z"></path>
      <path d="M1.462 18.217h21.543v-3.276h-21.543v3.276z"></path>
      <path d="M24.366 8.29l6.171-5.952-2.43-2.338-8.619 8.29 8.619 8.29 2.43-2.337-6.171-5.953z"></path>
    </symbol>
    <symbol id="vditor-icon-insert-column" viewBox="0 0 32 32">
      <path d="M5.493 1.462v21.543h3.276v-21.543h-3.276z"></path>
      <path d="M22.072 1.462v16.48h3.276v-16.48h-3.276z"></path>
      <path d="M13.783 1.462v21.543h3.276v-21.543h-3.276z"></path>
      <path d="M23.71 24.366l5.952 6.171 2.338-2.43-8.29-8.619-8.29 8.619 2.337 2.43 5.953-6.171z"></path>
    </symbol>
    <symbol id="vditor-icon-insert-columnb" viewBox="0 0 32 32">
      <path d="M26.507 1.462v21.543h-3.276v-21.543h3.276z"></path>
      <path d="M9.928 1.462v16.48h-3.276v-16.48h3.276z"></path>
      <path d="M18.217 1.462v21.543h-3.276v-21.543h3.276z"></path>
      <path d="M8.29 24.366l-5.952 6.171-2.338-2.43 8.29-8.619 8.29 8.619-2.337 2.43-5.953-6.171z"></path>
    </symbol>
    <symbol id="vditor-icon-code-theme" viewBox="0 0 32 32">
        <path d="M28.444 12.444v16h-24.924v-24.889h16v-3.556h-15.964c-1.956 0-3.556 1.6-3.556 3.556v24.889c0 1.956 1.6 3.556 3.556 3.556h24.889c1.956 0 3.556-1.6 3.556-3.556v-16h-3.556zM23.218 8.782l1.671 3.662 1.671-3.662 3.662-1.671-3.662-1.671-1.671-3.662-1.671 3.662-3.662 1.671zM16 8.889l-2.222 4.889-4.889 2.222 4.889 2.222 2.222 4.889 2.222-4.889 4.889-2.222-4.889-2.222z"></path>
    </symbol>
    <symbol id="vditor-icon-code" viewBox="0 0 32 32">
        <path d="M9.946 8.501l-2.204-1.832-7.742 9.331 7.742 9.331 2.204-1.832-6.225-7.499 6.225-7.499zM8.844 17.431h2.862v-2.862h-2.862v2.862zM23.156 14.569h-2.862v2.862h2.862v-2.862zM14.569 17.431h2.862v-2.862h-2.862v2.862zM24.258 6.669l-2.204 1.832 6.225 7.499-6.225 7.499 2.204 1.832 7.742-9.331-7.742-9.331z"></path>
    </symbol>
    <symbol id="vditor-icon-table" viewBox="0 0 32 32">
        <path d="M22.801 2.286h-22.801v27.429h32v-27.429h-9.199zM19.372 5.714v4.571h-6.801v-4.571h6.801zM19.372 13.714v4.571h-6.801v-4.571h6.801zM3.429 5.714h5.714v4.571h-5.714v-4.571zM3.429 13.714h5.714v4.571h-5.714v-4.571zM3.429 26.286v-4.571h5.714v4.571h-5.714zM12.571 26.286v-4.571h6.801v4.571h-6.801zM28.571 26.286h-5.77v-4.571h5.77v4.571zM28.571 18.286h-5.77v-4.571h5.77v4.571zM22.801 10.286v-4.571h5.77v4.571h-5.77z"></path>
    </symbol>
    <symbol id="vditor-icon-export" viewBox="0 0 32 32">
        <path d="M28.444 28.444h-24.889v-24.889h12.444v-3.556h-12.444c-1.973 0-3.556 1.6-3.556 3.556v24.889c0 1.956 1.582 3.556 3.556 3.556h24.889c1.956 0 3.556-1.6 3.556-3.556v-12.444h-3.556v12.444zM19.556 0v3.556h6.382l-17.476 17.476 2.507 2.507 17.476-17.476v6.382h3.556v-12.444h-12.444z"></path>
    </symbol>
    <symbol id="vditor-icon-resize" viewBox="0 0 128 32">
        <path d="M128 32v-5.334h-128v5.334h128zM128 18.666v-5.331h-128v5.331h128zM0 5.334h128v-5.334h-128v5.334z"></path>
    </symbol>
    <symbol id="vditor-icon-edit" viewBox="0 0 32 32">
        <path d="M19.66 10.703l1.635 1.635-16.104 16.104h-1.635v-1.635l16.104-16.104zM26.059 0.002c-0.444 0-0.907 0.178-1.244 0.515l-3.253 3.253 6.666 6.666 3.253-3.253c0.693-0.693 0.693-1.813 0-2.506l-4.159-4.159c-0.355-0.355-0.8-0.515-1.262-0.515zM19.66 5.673l-19.66 19.66v6.666h6.666l19.66-19.66-6.666-6.666z"></path>
    </symbol>
    <symbol id="vditor-icon-quote" viewBox="0 0 32 32">
        <path d="M27.769 26.667h-9.316l3.556-7.111h-4.231v-14.222h14.222v12.871l-4.231 8.462zM24.213 23.111h1.351l2.88-5.76v-8.462h-7.111v7.111h6.436l-3.556 7.111zM9.991 26.667h-9.316l3.556-7.111h-4.231v-14.222h14.222v12.871l-4.231 8.462zM6.436 23.111h1.351l2.88-5.76v-8.462h-7.111v7.111h6.436l-3.556 7.111z"></path>
    </symbol>
    <symbol id="vditor-icon-strike" viewBox="0 0 32 32">
        <path d="M12.444 29.333h7.111v-5.333h-7.111v5.333zM3.556 2.667v5.333h8.889v5.333h7.111v-5.333h8.889v-5.333h-24.889zM0 20.444h32v-3.556h-32v3.556z"></path>
    </symbol>
    <symbol id="vditor-icon-line" viewBox="0 0 32 32">
        <path d="M0 14h32v4h-32v-4z"></path>
    </symbol>
    <symbol id="vditor-icon-both" viewBox="0 0 32 32">
        <path d="M2.909 3.636h26.182c1.6 0 2.909 1.309 2.909 2.909v18.909c0 1.6-1.309 2.909-2.909 2.909h-26.182c-1.6 0-2.909-1.309-2.909-2.909v-18.909c0-1.6 1.309-2.909 2.909-2.909zM29.091 25.455v-18.909h-11.636v18.909h11.636zM2.909 25.455h11.636v-18.909h-11.636v18.909zM13.091 11.636h-8.727v2.182h8.727zM13.091 15.273h-8.727v2.182h8.727zM13.091 18.909h-8.727v2.182h8.727z"></path>
    </symbol>
    <symbol id="vditor-icon-copy" viewBox="0 0 32 32">
      <path d="M22.545-0h-17.455c-1.6 0-2.909 1.309-2.909 2.909v20.364h2.909v-20.364h17.455v-2.909zM26.909 5.818h-16c-1.6 0-2.909 1.309-2.909 2.909v20.364c0 1.6 1.309 2.909 2.909 2.909h16c1.6 0 2.909-1.309 2.909-2.909v-20.364c0-1.6-1.309-2.909-2.909-2.909zM26.909 29.091h-16v-20.364h16v20.364z"></path>
    </symbol>
    <symbol id="vditor-icon-trashcan" viewBox="0 0 32 32">
      <path d="M23.111 10.667v17.778h-14.222v-17.778h14.222zM20.444 0h-8.889l-1.778 1.778h-6.222v3.556h24.889v-3.556h-6.222l-1.778-1.778zM26.667 7.111h-21.333v21.333c0 1.956 1.6 3.556 3.556 3.556h14.222c1.956 0 3.556-1.6 3.556-3.556v-21.333z"></path>
    </symbol>
    <symbol id="vditor-icon-more" viewBox="0 0 32 32">
      <path d="M4 12c-2.2 0-4 1.8-4 4s1.8 4 4 4 4-1.8 4-4-1.8-4-4-4zM28 12c-2.2 0-4 1.8-4 4s1.8 4 4 4 4-1.8 4-4-1.8-4-4-4zM16 12c-2.2 0-4 1.8-4 4s1.8 4 4 4 4-1.8 4-4-1.8-4-4-4z"></path>
    </symbol>
    <symbol id="vditor-icon-upload" viewBox="0 0 32 32">
      <path d="M25.8 13.387c-0.907-4.6-4.947-8.053-9.8-8.053-3.853 0-7.2 2.187-8.867 5.387-4.013 0.427-7.133 3.827-7.133 7.947 0 4.413 3.587 8 8 8h17.333c3.68 0 6.667-2.987 6.667-6.667 0-3.52-2.733-6.373-6.2-6.613zM25.333 24h-17.333c-2.947 0-5.333-2.387-5.333-5.333 0-2.733 2.040-5.013 4.747-5.293l1.427-0.147 0.667-1.267c1.267-2.44 3.747-3.96 6.493-3.96 3.493 0 6.507 2.48 7.187 5.907l0.4 2 2.040 0.147c2.080 0.133 3.707 1.88 3.707 3.947 0 2.2-1.8 4-4 4zM10.667 17.333h3.4v4h3.867v-4h3.4l-5.333-5.333z"></path>
    </symbol>
    <symbol id="vditor-icon-bug" viewBox="0 0 32 32">
      <path d="M30.222 8.889h-4.996c-0.8-1.387-1.902-2.578-3.236-3.484l2.898-2.898-2.507-2.507-3.858 3.858c-0.818-0.196-1.653-0.302-2.524-0.302s-1.707 0.107-2.507 0.302l-3.876-3.858-2.507 2.507 2.88 2.898c-1.316 0.907-2.418 2.098-3.218 3.484h-4.996v3.556h3.716c-0.089 0.587-0.16 1.173-0.16 1.778v1.778h-3.556v3.556h3.556v1.778c0 0.604 0.071 1.191 0.16 1.778h-3.716v3.556h4.996c1.849 3.182 5.28 5.333 9.227 5.333s7.378-2.151 9.227-5.333h4.996v-3.556h-3.716c0.089-0.587 0.16-1.173 0.16-1.778v-1.778h3.556v-3.556h-3.556v-1.778c0-0.604-0.071-1.191-0.16-1.778h3.716v-3.556zM23.111 16v5.333c0 0.391-0.053 0.836-0.124 1.244l-0.178 1.156-0.658 1.156c-1.28 2.204-3.627 3.556-6.151 3.556s-4.871-1.369-6.151-3.556l-0.658-1.138-0.178-1.156c-0.071-0.409-0.124-0.853-0.124-1.262v-7.111c0-0.409 0.053-0.853 0.124-1.244l0.178-1.156 0.658-1.156c0.533-0.924 1.28-1.724 2.151-2.329l1.013-0.693 1.316-0.32c0.551-0.142 1.12-0.213 1.671-0.213 0.569 0 1.12 0.071 1.689 0.213l1.209 0.284 1.084 0.747c0.889 0.604 1.618 1.387 2.151 2.329l0.676 1.156 0.178 1.156c0.071 0.391 0.124 0.836 0.124 1.227v1.778zM12.444 19.556h7.111v3.556h-7.111zM12.444 12.445h7.111v3.556h-7.111z"></path>
    </symbol>
    <symbol id="vditor-icon-contract" viewBox="0 0 32 32">
      <path d="M32 2.256l-8.464 8.464 5.264 5.28h-12.8v-12.8l5.264 5.264 8.48-8.464 2.256 2.256zM2.256 32l8.464-8.464 5.28 5.264v-12.8h-12.8l5.264 5.264-8.464 8.48 2.256 2.256z"></path>
    </symbol>
    <symbol id="vditor-icon-inline-code" viewBox="0 0 32 32">
      <path d="M11.84 23.36l-7.36-7.36 7.36-7.36-2.24-2.24-9.6 9.6 9.6 9.6 2.24-2.24zM20.16 23.36l7.36-7.36-7.36-7.36 2.24-2.24 9.6 9.6-9.6 9.6-2.24-2.24z"></path>
    </symbol>
    <symbol id="vditor-icon-down" viewBox="0 0 32 32">
      <path d="M3.76 6.12l12.24 12.213 12.24-12.213 3.76 3.76-16 16-16-16 3.76-3.76z"></path>
    </symbol>
    <symbol id="vditor-icon-up" viewBox="0 0 32 32">
      <path d="M3.76 25.88l12.24-12.213 12.24 12.213 3.76-3.76-16-16-16 16 3.76 3.76z"></path>
    </symbol>
    <symbol id="vditor-icon-check" viewBox="0 0 32 32">
      <path d="M28.444 0h-24.889c-1.956 0-3.556 1.6-3.556 3.556v24.889c0 1.956 1.6 3.556 3.556 3.556h24.889c1.956 0 3.556-1.6 3.556-3.556v-24.889c0-1.956-1.6-3.556-3.556-3.556zM28.444 28.445h-24.889v-24.889h24.889v24.889zM26.649 10.667l-2.507-2.524-11.716 11.716-4.587-4.569-2.524 2.507 7.111 7.093z"></path>
    </symbol>
    <symbol id="vditor-icon-theme" viewBox="0 0 32 32">
      <path d="M16 32c-8.816 0-16-7.184-16-16s7.184-16 16-16 16 6.464 16 14.4c0 5.296-4.304 9.6-9.6 9.6h-2.832c-0.448 0-0.8 0.352-0.8 0.8 0 0.192 0.080 0.368 0.208 0.528 0.656 0.752 1.024 1.696 1.024 2.672 0 2.208-1.792 4-4 4zM16 3.2c-7.056 0-12.8 5.744-12.8 12.8s5.744 12.8 12.8 12.8c0.448 0 0.8-0.352 0.8-0.8 0-0.256-0.128-0.448-0.224-0.56-0.656-0.736-1.008-1.68-1.008-2.64 0-2.208 1.792-4 4-4h2.832c3.536 0 6.4-2.864 6.4-6.4 0-6.176-5.744-11.2-12.8-11.2z"></path>
      <path d="M9.6 15.2c0 1.325-1.075 2.4-2.4 2.4s-2.4-1.075-2.4-2.4c0-1.325 1.075-2.4 2.4-2.4s2.4 1.075 2.4 2.4z"></path>
      <path d="M14.4 8.8c0 1.325-1.075 2.4-2.4 2.4s-2.4-1.075-2.4-2.4c0-1.325 1.075-2.4 2.4-2.4s2.4 1.075 2.4 2.4z"></path>
      <path d="M22.4 8.8c0 1.325-1.075 2.4-2.4 2.4s-2.4-1.075-2.4-2.4c0-1.325 1.075-2.4 2.4-2.4s2.4 1.075 2.4 2.4z"></path>
      <path d="M27.2 15.2c0 1.325-1.075 2.4-2.4 2.4s-2.4-1.075-2.4-2.4c0-1.325 1.075-2.4 2.4-2.4s2.4 1.075 2.4 2.4z"></path>
    </symbol>
    <symbol id="vditor-icon-help" viewBox="0 0 32 32">
      <path d="M14.4 25.6h3.2v-3.2h-3.2v3.2zM16 0c-8.832 0-16 7.168-16 16s7.168 16 16 16 16-7.168 16-16-7.168-16-16-16zM16 28.8c-7.056 0-12.8-5.744-12.8-12.8s5.744-12.8 12.8-12.8 12.8 5.744 12.8 12.8-5.744 12.8-12.8 12.8zM16 6.4c-3.536 0-6.4 2.864-6.4 6.4h3.2c0-1.76 1.44-3.2 3.2-3.2s3.2 1.44 3.2 3.2c0 3.2-4.8 2.8-4.8 8h3.2c0-3.6 4.8-4 4.8-8 0-3.536-2.864-6.4-6.4-6.4z"></path>
    </symbol>
    <symbol id="vditor-icon-info" viewBox="0 0 32 32">
      <path d="M14.4 8h3.2v3.2h-3.2zM14.4 14.4h3.2v9.6h-3.2zM16 0c-8.832 0-16 7.168-16 16s7.168 16 16 16 16-7.168 16-16-7.168-16-16-16zM16 28.8c-7.056 0-12.8-5.744-12.8-12.8s5.744-12.8 12.8-12.8 12.8 5.744 12.8 12.8-5.744 12.8-12.8 12.8z"></path>
    </symbol>
    <symbol id="vditor-icon-fullscreen" viewBox="0 0 32 32">
      <path d="M32 14.222v-14.222h-14.222l5.849 5.849-17.778 17.778-5.849-5.849v14.222h14.222l-5.849-5.849 17.778-17.778z"></path>
    </symbol>
    <symbol id="vditor-icon-preview" viewBox="0 0 32 32">
      <path d="M16 8c5.513 0 10.429 3.098 12.829 8-2.4 4.902-7.302 8-12.829 8s-10.429-3.098-12.829-8c2.4-4.902 7.316-8 12.829-8zM16 5.091c-7.273 0-13.484 4.524-16 10.909 2.516 6.385 8.727 10.909 16 10.909s13.484-4.524 16-10.909c-2.516-6.385-8.727-10.909-16-10.909zM16 12.364c2.007 0 3.636 1.629 3.636 3.636s-1.629 3.636-3.636 3.636-3.636-1.629-3.636-3.636 1.629-3.636 3.636-3.636zM16 9.455c-3.607 0-6.545 2.938-6.545 6.545s2.938 6.545 6.545 6.545 6.545-2.938 6.545-6.545-2.938-6.545-6.545-6.545z"></path>
    </symbol>
    <symbol id="vditor-icon-record" viewBox="0 0 32 32">
      <path d="M24.928 15.17h2.844q0 4.267-2.963 7.467t-7.151 3.832v5.531h-3.319v-5.531q-4.188-0.632-7.151-3.832t-2.963-7.467h2.844q0 3.714 2.647 6.123t6.281 2.41 6.281-2.41 2.647-6.123zM13.946 4.899v10.43q0 0.79 0.593 1.383t1.462 0.593q0.79 0 1.383-0.553t0.593-1.422l0.079-10.43q0-0.869-0.632-1.462t-1.422-0.593-1.422 0.593-0.632 1.462zM16 20.227q-2.054 0-3.556-1.501t-1.501-3.556v-10.114q0-2.054 1.501-3.556t3.556-1.501 3.556 1.501 1.501 3.556v10.114q0 2.054-1.501 3.556t-3.556 1.501z"></path>
    </symbol>
    <symbol id="vditor-icon-pause" viewBox="0 0 32 32">
      <path d="M20.617 0h9.128v32h-9.128v-32zM2.255 32v-32h9.128v32h-9.128z"></path>
    </symbol>
    <symbol id="vditor-icon-play" viewBox="0 0 32 32">
      <path d="M3.436 0l25.128 16-25.128 16v-32z"></path>
    </symbol>
    <symbol id="vditor-icon-emoji" viewBox="0 0 32 32">
      <path d="M16 24.789q-2.779 0-4.995-1.54t-3.192-4.019h2.629q1.878 3.155 5.559 3.155t5.559-3.155h2.629q-0.977 2.479-3.192 4.019t-4.995 1.54zM16 28.845q5.258 0 9.052-3.793t3.793-9.052-3.793-9.052-9.052-3.793-9.052 3.793-3.793 9.052 3.793 9.052 9.052 3.793zM16 0q6.61 0 11.305 4.695t4.695 11.305-4.695 11.305-11.305 4.695-11.305-4.695-4.695-11.305 4.695-11.305 11.305-4.695zM10.366 14.423q-0.977 0-1.69-0.714t-0.714-1.69 0.714-1.69 1.69-0.714 1.69 0.714 0.714 1.69-0.714 1.69-1.69 0.714zM21.634 14.423q-0.977 0-1.69-0.714t-0.714-1.69 0.714-1.69 1.69-0.714 1.69 0.714 0.714 1.69-0.714 1.69-1.69 0.714z"></path>
    </symbol>
    <symbol id="vditor-icon-link" viewBox="0 0 32 32">
      <path d="M24.038 7.962q3.305 0 5.634 2.366t2.329 5.671-2.329 5.671-5.634 2.366h-6.46v-3.080h6.46q2.028 0 3.493-1.465t1.465-3.493-1.465-3.493-3.493-1.465h-6.46v-3.080h6.46zM9.615 17.577v-3.155h12.77v3.155h-12.77zM3.005 16q0 2.028 1.465 3.493t3.493 1.465h6.46v3.080h-6.46q-3.305 0-5.634-2.366t-2.329-5.671 2.329-5.671 5.634-2.366h6.46v3.080h-6.46q-2.028 0-3.493 1.465t-1.465 3.493z"></path>
    </symbol>
    <symbol id="vditor-icon-redo" viewBox="0 0 32 32">
      <path d="M26.422 14.605l5.578-5.651v14.092h-14.092l5.725-5.651q-3.523-2.936-8.073-2.936-3.743 0-7.229 2.495t-4.661 6.092l-3.67-1.174q1.615-4.991 5.908-8.147t9.651-3.156q6.239 0 10.862 4.037z"></path>
    </symbol>
    <symbol id="vditor-icon-undo" viewBox="0 0 32 32">
      <path d="M16.44 10.569q5.358 0 9.615 3.156t5.945 8.147l-3.67 1.174q-1.248-3.817-4.514-6.202t-7.376-2.385q-4.55 0-8.073 2.936l5.725 5.651h-14.092v-14.092l5.578 5.651q4.624-4.037 10.862-4.037z"></path>
    </symbol>
    <symbol id="vditor-icon-align-center" viewBox="0 0 32 32">
      <path d="M0 0h32v3.583h-32v-3.583zM7.083 7.083h17.833v3.583h-17.833v-3.583zM0 17.75v-3.5h32v3.5h-32zM0 32v-3.583h32v3.583h-32zM7.083 21.333h17.833v3.583h-17.833v-3.583z"></path>
    </symbol>
    <symbol id="vditor-icon-align-left" viewBox="0 0 32 32">
      <path d="M0 0h32v3.583h-32v-3.583zM0 32v-3.583h32v3.583h-32zM0 17.75v-3.5h32v3.5h-32zM21.333 7.083v3.583h-21.333v-3.583h21.333zM21.333 21.333v3.583h-21.333v-3.583h21.333z"></path>
    </symbol>
    <symbol id="vditor-icon-align-right" viewBox="0 0 32 32">
      <path d="M0 0h32v3.583h-32v-3.583zM10.667 10.667v-3.583h21.333v3.583h-21.333zM0 17.75v-3.5h32v3.5h-32zM10.667 24.917v-3.583h21.333v3.583h-21.333zM0 32v-3.583h32v3.583h-32z"></path>
    </symbol>
    <symbol id="vditor-icon-bold" viewBox="0 0 32 32">
      <path d="M18.569 26.328q1.498 0 2.462-1.017t0.963-2.408-0.963-2.408-2.462-1.017h-8.027v6.849h8.027zM10.542 5.779v6.85h6.85q1.391 0 2.408-1.017t1.017-2.408-1.017-2.408-2.408-1.017h-6.849zM23.385 15.518q4.923 2.248 4.923 7.813 0 3.639-2.408 6.154t-6.047 2.515h-16.161v-32h14.341q3.853 0 6.475 2.676t2.622 6.528-3.746 6.314z"></path>
    </symbol>
    <symbol id="vditor-icon-outdent" viewBox="0 0 32 32">
      <path d="M14.25 17.75v-3.5h17.75v3.5h-17.75zM14.25 10.667v-3.583h17.75v3.583h-17.75zM0 0h32v3.583h-32v-3.583zM0 32v-3.583h32v3.583h-32zM0 16l7.083-7.083v14.167zM14.25 24.917v-3.583h17.75v3.583h-17.75z"></path>
    </symbol>
    <symbol id="vditor-icon-indent" viewBox="0 0 32 32">
      <path d="M14.25 17.75v-3.5h17.75v3.5h-17.75zM14.25 10.667v-3.583h17.75v3.583h-17.75zM0 0h32v3.583h-32v-3.583zM14.25 24.917v-3.583h17.75v3.583h-17.75zM0 8.917l7.083 7.083-7.083 7.083v-14.167zM0 32v-3.583h32v3.583h-32z"></path>
    </symbol>
    <symbol id="vditor-icon-italic" viewBox="0 0 32 32">
      <path d="M11.398 0h18.301v6.849h-6.421l-7.706 18.301h5.030v6.849h-18.301v-6.849h6.421l7.706-18.301h-5.030v-6.849z"></path>
    </symbol>
    <symbol id="vditor-icon-list" viewBox="0 0 32 32">
      <path d="M7.777 3.929h24.223v3.403h-24.223v-3.403zM7.777 17.701v-3.403h24.223v3.403h-24.223zM7.777 28.071v-3.403h24.223v3.403h-24.223zM2.592 23.777q1.053 0 1.823 0.77t0.77 1.823-0.77 1.823-1.823 0.77-1.823-0.77-0.77-1.823 0.77-1.823 1.823-0.77zM2.592 3.038q1.053 0 1.823 0.729t0.77 1.863-0.77 1.863-1.823 0.729-1.823-0.729-0.77-1.863 0.77-1.863 1.823-0.729zM2.592 13.408q1.053 0 1.823 0.729t0.77 1.863-0.77 1.863-1.823 0.729-1.823-0.729-0.77-1.863 0.77-1.863 1.823-0.729z"></path>
    </symbol>
    <symbol id="vditor-icon-ordered-list" viewBox="0 0 32 32">
      <path d="M8.375 17.659v-3.319h23.625v3.319h-23.625zM8.375 27.773v-3.319h23.625v3.319h-23.625zM8.375 4.227h23.625v3.319h-23.625v-3.319zM0 14.341v-1.738h5.057v1.58l-3.081 3.477h3.081v1.738h-5.057v-1.58l3.002-3.477h-3.002zM1.659 9.284v-5.057h-1.659v-1.738h3.319v6.795h-1.659zM0 24.454v-1.738h5.057v6.795h-5.057v-1.738h3.319v-0.79h-1.659v-1.738h1.659v-0.79h-3.319z"></path>
    </symbol>
    <symbol id="vditor-icon-mp-wechat" viewBox="0 0 32 32">
      <path d="M6.927 17.719s-3.040-3.431-2.915-6.942c0.16-4.453 4.738-10.257 11.359-10.257 1.884 0 5.653 0 10.328 5.52 0.249 0.302-15.075-3.84-18.772 11.679z"></path>
      <path d="M17.477 9.301s3.946-1.298 7.271-0.178c4.222 1.422 8.693 6.826 6.809 13.182-0.533 1.804-1.609 5.413-8.231 8.32-0.356 0.16 10.613-13.351-5.849-21.323z"></path>
      <path d="M10.944 24.332c-1.938 2.035-3.751 1.742-3.751 1.742l0.578-3.191c-5.235-3.44-6.373-10.328-6.453-10.106-2.444 6.817-0.916 11.377 0.027 13.004 3.315 5.733 11.982 7.351 17.484 3.893 2.969-1.867 4.533-7.057 4.533-7.057-5.298 2.338-9.342 2.569-12.417 1.715z"></path>
    </symbol>
    <symbol id="vditor-icon-zhihu" viewBox="0 0 32 32">
      <path d="M17.167 17.769s0-2.583-1.25-2.667c-1.25-0.167-5.167 0-5.167 0v-8h5.833s-0.083-2.667-1.167-2.667h-9.5l1.583-4.25s-2.333 0.167-3.25 1.667c-0.833 1.5-3.5 9.167-3.5 9.167s0.917 0.417 2.417-0.75c1.5-1.083 2-3.083 2-3.083l2.75-0.167 0.083 8.083s-4.917-0.083-5.833 0c-1 0.083-1.5 2.667-1.5 2.667h7.417s-0.667 4.583-2.5 7.75c-1.917 3.333-5.583 5.917-5.583 5.917s2.583 1.083 5.167-0.417 4.417-8.083 4.417-8.083l5.917 7.417s0.5-3.5-0.083-4.583c-0.667-1-4.167-5-4.167-5l-1.5 1.333 1.083-4.417 6.333 0.083zM18.667 4.269l-0.083 23.999h2.417l0.833 2.917 4.25-2.917h5.917v-23.999h-13.333zM29.333 25.602h-2.75l-3.5 2.667-0.75-2.667h-0.75v-18.582h7.75v18.582z"></path>
    </symbol>
  </defs>
</svg>`)
