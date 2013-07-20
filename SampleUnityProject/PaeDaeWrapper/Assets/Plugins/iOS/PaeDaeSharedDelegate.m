//
//  PaeDaeSharedDelegate.m
//
//  Created by Miguel Morales on 7/19/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

#import "PaeDaeSharedDelegate.h"

@implementation PaeDaeSharedDelegate

static PaeDaeSharedDelegate *sharedDelegate = nil;

#pragma mark - static singleton access method

+ (id) sharedDelegate
{
    if (self == [PaeDaeSharedDelegate class] && !sharedDelegate)
    {
        sharedDelegate = [[PaeDaeSharedDelegate alloc] init];
    }
    
    return sharedDelegate;
}

#pragma mark - PaeDaeInitDelegate callbacks

- (void) PaeDae_Initialized
{
    NSLog(@"%s - PaeDae SDK initialized", __FUNCTION__);
    UnitySendMessage("PaeDaeWrapper", "Initialized", nil);
}

- (void) PaeDae_InitializeFailed
{
    NSLog(@"%s - PaeDae SDK failed to load!", __FUNCTION__);
    UnitySendMessage("PaeDaeWrapper", "InitializeFailed", nil);
}

#pragma mark - PaeDaeAdDelegate callbacks

- (void) PaeDae_AdWillDisplay:(UIView *)view
{
    NSLog(@"%s - PaeDae ad is about to display", __FUNCTION__);
    UnitySendMessage("PaeDaeWrapper", "AdWillDisplay", nil);    
}

- (void) PaeDae_AdUnloaded
{
    NSLog(@"%s - PaeDae ad unloaded", __FUNCTION__);
    UnitySendMessage("PaeDaeWrapper", "AdUnloaded", nil);    
}

- (void) PaeDae_AdUnavailable
{
    NSLog(@"%s - no ad available from PaeDae", __FUNCTION__);
    UnitySendMessage("PaeDaeWrapper", "AdUnavailable", nil);
}

@end