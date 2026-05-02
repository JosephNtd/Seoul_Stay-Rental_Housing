---
name: Nordic Softness
colors:
  surface: '#fff8f4'
  surface-dim: '#e2d8d2'
  surface-bright: '#fff8f4'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#fcf2eb'
  surface-container: '#f6ece5'
  surface-container-high: '#f0e6e0'
  surface-container-highest: '#eae1da'
  on-surface: '#1f1b17'
  on-surface-variant: '#504444'
  inverse-surface: '#34302b'
  inverse-on-surface: '#f9efe8'
  outline: '#827473'
  outline-variant: '#d4c2c2'
  surface-tint: '#7b5455'
  primary: '#7b5455'
  on-primary: '#ffffff'
  primary-container: '#f4c2c2'
  on-primary-container: '#734e4e'
  inverse-primary: '#ecbaba'
  secondary: '#3f6658'
  on-secondary: '#ffffff'
  secondary-container: '#c1ecda'
  on-secondary-container: '#456c5e'
  tertiary: '#635e53'
  on-tertiary: '#ffffff'
  tertiary-container: '#d4cdbf'
  on-tertiary-container: '#5b574c'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#ffdad9'
  primary-fixed-dim: '#ecbaba'
  on-primary-fixed: '#2f1314'
  on-primary-fixed-variant: '#613d3e'
  secondary-fixed: '#c1ecda'
  secondary-fixed-dim: '#a6cfbf'
  on-secondary-fixed: '#002118'
  on-secondary-fixed-variant: '#274e41'
  tertiary-fixed: '#e9e2d3'
  tertiary-fixed-dim: '#cdc6b8'
  on-tertiary-fixed: '#1e1b13'
  on-tertiary-fixed-variant: '#4b463c'
  background: '#fff8f4'
  on-background: '#1f1b17'
  surface-variant: '#eae1da'
typography:
  headline-lg:
    fontFamily: Plus Jakarta Sans
    fontSize: 40px
    fontWeight: '700'
    lineHeight: '1.2'
    letterSpacing: -0.02em
  headline-md:
    fontFamily: Plus Jakarta Sans
    fontSize: 28px
    fontWeight: '600'
    lineHeight: '1.3'
  headline-sm:
    fontFamily: Plus Jakarta Sans
    fontSize: 20px
    fontWeight: '600'
    lineHeight: '1.4'
  body-lg:
    fontFamily: Be Vietnam Pro
    fontSize: 18px
    fontWeight: '400'
    lineHeight: '1.6'
  body-md:
    fontFamily: Be Vietnam Pro
    fontSize: 16px
    fontWeight: '400'
    lineHeight: '1.6'
  label-md:
    fontFamily: Be Vietnam Pro
    fontSize: 14px
    fontWeight: '600'
    lineHeight: '1.2'
    letterSpacing: 0.01em
  label-sm:
    fontFamily: Be Vietnam Pro
    fontSize: 12px
    fontWeight: '500'
    lineHeight: '1.2'
rounded:
  sm: 0.5rem
  DEFAULT: 1rem
  md: 1.5rem
  lg: 2rem
  xl: 3rem
  full: 9999px
spacing:
  unit: 8px
  container-padding: 32px
  gutter: 24px
  section-gap: 64px
---

## Brand & Style
This design system is built on the principles of *hygge*—creating a digital environment that feels safe, warm, and inherently human. It targets lifestyle, wellness, and home-oriented products where the goal is to reduce cognitive load and evoke a sense of calm. 

The aesthetic blends **Minimalism** with **Tactile** warmth. It avoids the clinical coldness often found in modern tech by utilizing organic, free-form geometry and a soft, low-contrast color palette. Interfaces should feel like a physical space filled with natural light, soft fabrics, and smooth wooden surfaces.

## Colors
The palette is rooted in a "Warm Cream" base, replacing pure white to eliminate harsh screen glare. 
- **Primary (Pastel Pink):** Used for key actions and subtle highlights. It is soft but purposeful.
- **Secondary (Mint Green):** Used for success states, secondary accents, and to provide a refreshing contrast to the pink.
- **Tertiary (Warm Cream):** The foundation of the UI. All containers and background layers utilize this or a slightly desaturated variant.
- **Neutral (Soft Charcoal):** Used for typography to maintain high readability without the "vibration" of pure black on cream.

## Typography
The typography strategy prioritizes approachability. **Plus Jakarta Sans** provides a modern, slightly rounded geometric structure for headlines, giving the design system a friendly but organized character. **Be Vietnam Pro** is used for body copy and labels; its open counters and warm curves ensure high legibility while maintaining the cozy aesthetic. Use generous line heights to allow the text to "breathe" within the layout.

## Layout & Spacing
The layout follows a **fluid grid** model with significant emphasis on whitespace. To maintain the "Nordic" feel, elements should never feel crowded. 

Margins and paddings are larger than standard utility-first systems to create an airy atmosphere. A 12-column grid is used for desktop, but internal container padding should be generous (32px+) to ensure content is cushioned from the edges. Components should use an 8px stepping scale, favoring larger gaps (24px, 32px, 48px) to reinforce the minimalist philosophy.

## Elevation & Depth
Depth is conveyed through **Tonal Layers** and **Ambient Shadows**. 
- **Surface Strategy:** Instead of using shadows to lift every element, use subtle color shifts between the background (Cream) and containers (White or very light Mint/Pink).
- **Shadows:** When depth is required (e.g., for modals or floating buttons), use "Cloud Shadows"—ultra-diffused, large-radius blurs with very low opacity (5-8%) and a slight tint of the primary pink or neutral charcoal to prevent them from looking grey or "dirty."
- **Glass:** Subtle backdrop blurs (8px - 12px) can be used for navigation bars to suggest a frosted glass texture.

## Shapes
Shapes are the defining characteristic of this design system. 
- **Corners:** Everything is highly rounded, bordering on pill-shaped for smaller components. 
- **Organic Geometry:** Large image containers and hero sections should utilize "wavy" CSS masks or SVG blobs to break the rigidity of the grid. 
- **Cutouts:** Use free-form, asymmetrical cutouts for image frames, moving away from standard rectangles or circles toward "pebble" and "leaf" shapes.

## Components
- **Buttons:** Fully pill-shaped (`rounded-full`). The primary button uses a soft pink background with dark charcoal text. Avoid heavy gradients; use a subtle 1px inner light border to simulate a soft edge.
- **Cards:** Use `rounded-3xl` (24px - 32px). Cards should have no borders; depth is created by a slight tonal difference from the background or a faint ambient shadow.
- **Inputs:** Soft cream backgrounds with a 2px border that appears only on focus in a mint green color. Corners should be `rounded-2xl`.
- **Chips/Badges:** Small, pill-shaped elements using the secondary mint green at 20% opacity with dark green text.
- **Selection Controls:** Checkboxes and radios should be oversized and highly rounded. When active, they should "squish" slightly (a subtle scale-down animation) to feel tactile.
- **Wavy Dividers:** Use organic, flowing SVG waves instead of straight horizontal lines to separate major page sections.